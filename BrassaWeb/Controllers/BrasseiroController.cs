using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrassaWeb.Models;
using Microsoft.AspNetCore.Authorization;
using DataRepository.Data;

namespace BrassaWeb.Controllers
{
    [Authorize]
    public class BrasseiroController : BaseController<Brasseiro>
    {
        private readonly IRepository<EstoqueReceita> _REstoque;
        private readonly IRepository<Receita> _RReceita;

        public BrasseiroController(
            IRepository<EstoqueReceita> rEstoque,
            IRepository<Receita> rReceita,
            IRepository<Brasseiro> repositoty) : base(repositoty)
        {
            _REstoque = rEstoque;
            _RReceita = rReceita;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0)]
        public async Task<IActionResult> GetBrasseirosCidade(int idCidade)
        {
            try
            {
                var brasseiros = _Repository.GetList(b => b.Cidade.Id == idCidade);
                foreach (var brasseiro in brasseiros)
                {
                    brasseiro.Estoques = _REstoque.GetList(e => e.Brasseiro.Id == brasseiro.Id).ToList();
                    foreach (var estoque in brasseiro.Estoques)
                    {
                        estoque.Receita = await _RReceita.GetById(estoque.Receita.Id);
                    }
                }
                return PartialView("_ListaBrasseiros", brasseiros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0)]
        public IActionResult GetEstoqueBrasseiro(int idBrasseiro)
        {
            try
            {
                var estoques = _REstoque.GetList(e => e.Brasseiro.Id == idBrasseiro);
                return PartialView("_EstoqueBrasseiro", estoques);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ResponseCache(Duration = 0)]
        public async Task<IActionResult> GetDetalheEstoque(int idEstoque)
        {
            try
            {
                return PartialView("_DetalheEstoque", await _REstoque.GetById(idEstoque));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}