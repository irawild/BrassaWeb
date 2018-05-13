using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrassaWeb.Models;
using Microsoft.AspNetCore.Authorization;
using DataRepository.Data;
using BrassaWeb.Models.DTO;

namespace BrassaWeb.Controllers
{
    [Authorize]
    public class RecipienteController : BaseController<Recipiente>
    {
        private readonly IRepository<ItemVenda> _RItemVenda;
        private readonly IRepository<EstoqueReceita> _REstoqueReceita;
        private readonly IRepository<EstoqueRecipiente> _REstoqueRecipiente;
        public RecipienteController(
            IRepository<ItemVenda> rItemVenda,
            IRepository<EstoqueReceita> rEstoqueReceita,
            IRepository<EstoqueRecipiente> rEstoqueRecipiente,
            IRepository<Recipiente> repositoty) : base(repositoty)
        {
            _RItemVenda = rItemVenda;
            _REstoqueReceita = rEstoqueReceita;
            _REstoqueRecipiente = rEstoqueRecipiente;
        }

        //[AllowAnonymous]
        [HttpPost]
        [ResponseCache(Duration = 0)]
        public async Task<IActionResult> GetRowCarrinho(DTOPrecoItem dto)
        {
            try
            {
                var estoqueRecipiente = _REstoqueRecipiente.GetList(e => e.Id == dto.IdRecipiente && e.Brasseiro.Id == dto.IdBrasseiro).FirstOrDefault();
                var estoqueRecipientes = _REstoqueRecipiente.GetList(e => e.Brasseiro.Id == dto.IdBrasseiro).ToList();
                var recipiente = await _Repository.GetById(estoqueRecipiente.Recipiente.Id);
                var itemVenda = await _RItemVenda.GetById(dto.IdItemVenda);
                var estoqueReceita = _REstoqueReceita.GetList(e => e.Receita.Id == itemVenda.Receita.Id && e.Brasseiro.Id == dto.IdBrasseiro).FirstOrDefault();

                ViewBag.ListaRecipientes = estoqueRecipientes;

                dto.PrecoReceita = estoqueReceita.PrecoLitro;
                dto.PrecoRecipiente = estoqueRecipiente.ValorUnidade;
                dto.PrecoCompleto = dto.PrecoReceita * estoqueRecipiente.Recipiente.Volume + dto.PrecoRecipiente;

                itemVenda.ValorReceita = dto.PrecoCompleto;
                itemVenda.QuantidadeRecipiente = dto.QuantidadeVenda;
                itemVenda.ValorItem = dto.PrecoCompleto * dto.QuantidadeVenda;

				itemVenda = await _RItemVenda.Update(itemVenda, true);

                return PartialView("_RowCarrinho", itemVenda);

                //return Ok(dto);
            }
            catch (Exception ex)
            {
                throw ex;
                //return Ok(new DataRepository.ErrorHandling.ErrorViewModel() { TemErro = true, Message = ex.Message });
            }
        }

        //[HttpGet]
        //[ResponseCache(Duration = 0)]
        //public async Task<IActionResult> GetRowCarrinhoItem(ItemVenda itemVenda)
        //{
        //    try
        //    {
        //        var estoqueRecipiente = _REstoqueRecipiente.GetList(e => e.Id == dto.IdRecipiente && e.Brasseiro.Id == dto.IdBrasseiro).FirstOrDefault();
        //        var recipiente = await _Repository.GetById(estoqueRecipiente.Recipiente.Id);
        //        var itemVenda = await _RItemVenda.GetById(dto.IdItemVenda);
        //        var estoqueReceita = _REstoqueReceita.GetList(e => e.Receita.Id == itemVenda.Receita.Id && e.Brasseiro.Id == dto.IdBrasseiro).FirstOrDefault();

        //        dto.PrecoReceita = estoqueReceita.PrecoLitro;
        //        dto.PrecoRecipiente = estoqueRecipiente.ValorUnidade;
        //        dto.PrecoCompleto = dto.PrecoReceita * estoqueRecipiente.Recipiente.Volume + dto.PrecoRecipiente;


        //        return Ok(dto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataRepository.ErrorHandling.ErrorViewModel() { TemErro = true, Message = ex.Message });
        //    }
        //}

    }

}