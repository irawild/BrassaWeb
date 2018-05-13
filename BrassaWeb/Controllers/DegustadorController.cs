using System;
using System.Linq;
using System.Threading.Tasks;
using BrassaWeb.Models;
using DataRepository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BrassaWeb.Controllers
{
    [Authorize]
    public class DegustadorController : BaseController<Degustador>
    {
        private readonly IRepository<Estado> _REstado;
        private readonly IRepository<EstoqueReceita> _REstoque;
        private readonly IRepository<Cidade> _RCidade;
        private readonly IRepository<Venda> _RVenda;
        private readonly IRepository<Recipiente> _RRecipiente;
        private readonly IRepository<EstoqueRecipiente> _REstoqueRecipiente;

        public DegustadorController(
            IRepository<Degustador> repositoty,
            IRepository<Cidade> rCidade,
            IRepository<Venda> rVenda,
            IRepository<EstoqueReceita> rEstoqueReceita,
            IRepository<Recipiente> rRecipiente,
            IRepository<EstoqueRecipiente> rEstoqueRecipiente,
            IRepository<Estado> rEstado) : base(repositoty)
        {
            _REstado = rEstado;
            _REstoque = rEstoqueReceita;
            _RCidade = rCidade;
            _RVenda = rVenda;
            _RRecipiente = rRecipiente;
            _REstoqueRecipiente = rEstoqueRecipiente;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Degustador()
        {
            ViewBag.ListaEstados = _REstado.GetList();
            var degustador = _Repository.GetList(d => d.UserId.Equals(User.Identity.Name)).FirstOrDefault();
            return View(degustador);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Degustador degustador)
        {
            try
            {
                if (degustador.Id == 0)
                {
                    degustador.Cidade = await _RCidade.GetById(degustador.Cidade.Id);
                    degustador.UserId = User.Identity.Name;
                    degustador = await _Repository.Add(degustador, true);
                    return Ok(degustador);
                }
                else
                {
                    degustador = await _Repository.Update(degustador, true);
                    return Ok(degustador);
                }
            }
            catch (Exception ex)
            {
                return Ok(new DataRepository.ErrorHandling.ErrorViewModel() { TemErro = true, Message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListaCarrinhos()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult HaVendas()
        {
            var degustador = _Repository.GetList(d => d.UserId.Equals(User.Identity.Name)).FirstOrDefault();

            if (degustador == null)
                return Ok("No");

            var vendaDegustador = _RVenda.GetList(v => v.Degustador.Id == degustador.Id && v.Situacao.Equals("Pedido")).FirstOrDefault();

            if (vendaDegustador == null)
                return Ok("No");
            else
                return Ok("Yes");
        }

        [HttpGet]
        public async Task<IActionResult> Carrinho(int? idEstoque)
        {
            try
            {
                var estoque = await _REstoque.GetById(idEstoque.Value);
                var estoqueRecipiente = _REstoqueRecipiente.GetList(e => e.Brasseiro.Id == estoque.Brasseiro.Id).ToList();
                var degustador = _Repository.GetList(d => d.UserId.Equals(User.Identity.Name)).FirstOrDefault();

                ViewBag.ListaRecipientes = estoqueRecipiente;
                ViewBag.Estoques = _REstoque.GetList(e => e.Brasseiro.Id == estoque.Brasseiro.Id).ToList();

                var vendaDegustador = _RVenda.GetList(v => v.Degustador.Id == degustador.Id && v.Situacao.Equals("Pedido")).FirstOrDefault();
                
                if (vendaDegustador != null)
                {
					if (vendaDegustador.Brasseiro.Id != estoque.Brasseiro.Id)
                    {
                        ViewBag.VendaAberta = true;
                    }

                    if (vendaDegustador.ItensVenda.FirstOrDefault(i => i.Receita.Id == estoque.Receita.Id) == null)
                    {
                        ItemVenda item = new ItemVenda()
                        {
                            Id = 0,
                            QuantidadeReceita = 0,
                            QuantidadeRecipiente = 0,
                            Receita = estoque.Receita,
                            ValorReceita = 0,
                            ValorRecipiente = 0,
                            ValorItem = 0
                        };
                        if (estoqueRecipiente != null && estoqueRecipiente.Count > 0)
                        {
                            item.Recipiente = estoqueRecipiente.FirstOrDefault().Recipiente;
                        }
                        vendaDegustador.ItensVenda.Add(item);
                        vendaDegustador = await _RVenda.Update(vendaDegustador, true);
                    }
                }
                else
                {
                    vendaDegustador = new Venda()
                    {
                        Id = 0,
                        Situacao = "Pedido",
                        Brasseiro = estoque.Brasseiro,
                        Degustador = degustador
                    };
                    ItemVenda item = new ItemVenda()
                    {
                        Id = 0,
                        QuantidadeReceita = 0,
                        QuantidadeRecipiente = 0,
                        Receita = estoque.Receita,
                        ValorReceita = 0,
                        ValorRecipiente = 0,
                        ValorItem = 0
                    };
                    if (estoqueRecipiente != null && estoqueRecipiente.Count > 0)
                    {
                        item.Recipiente = estoqueRecipiente.FirstOrDefault().Recipiente;
                    }
                    vendaDegustador.ItensVenda = new List<ItemVenda>();
                    vendaDegustador.ItensVenda.Add(item);
                    vendaDegustador = await _RVenda.Add(vendaDegustador, true);
                }

                return View(vendaDegustador);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		[HttpPost]
        [ResponseCache(Duration = 0)]
		public async Task<IActionResult> FecharCarrinho(int idVenda)
		{
			try
			{
    			var venda = await _RVenda.GetById(idVenda);
    			venda.ValorItens = 0;
                foreach (var item in venda.ItensVenda)
    			{
    				venda.ValorItens += item.ValorItem;
    			}
    			venda.ValorBrassa = venda.ValorItens * (decimal)0.05;
    			venda.ValorParcial = venda.ValorItens + venda.ValorBrassa;
    			venda.ValorTotalAPagar = venda.ValorParcial;
                venda = await _RVenda.Update(venda, true);
                venda.ValorTotalAPagar *= 100;
                return Ok(venda);
            }
            catch (Exception ex)
            {
				return Ok(new DataRepository.ErrorHandling.ErrorViewModel() { TemErro = true, Message = ex.Message });
            }
		}

		[HttpPost]
        public async Task<IActionResult> MarcarVendaPaga(int idVenda)
		{
			try
			{
				var venda = await _RVenda.GetById(idVenda);
				venda.Situacao = "Pago";
				venda = await _RVenda.Update(venda, true);
				return Ok(venda);
			}
			catch (Exception ex)
			{
					return Ok(new DataRepository.ErrorHandling.ErrorViewModel() { TemErro = true, Message = ex.Message });
			}
		}

        public IActionResult MeuBrassa()
		{
			var degustador = _Repository.GetList(d => d.UserId.Equals(User.Identity.Name)).FirstOrDefault();
			return View(degustador);
		}

        [ResponseCache(Duration = 0)]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
		public async Task<IActionResult> ListarCarrinhos(int idDegustador)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
		{
			return PartialView("_ListaCarrinhos", _RVenda.GetList(v => v.Degustador.Id == idDegustador).ToList());
		}

        [HttpGet]
        [ResponseCache(Duration = 0)]
        public async Task<IActionResult> AbrirPedido(int idVenda)
		{
			var venda = await _RVenda.GetById(idVenda);
			var estoqueRecipiente = _REstoqueRecipiente.GetList(e => e.Brasseiro.Id == venda.Brasseiro.Id).ToList();
            ViewBag.ListaRecipientes = estoqueRecipiente;
			return View("Carrinho", venda);
		}
    }
}