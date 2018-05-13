using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrassaWeb.Models;
using DataRepository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrassaWeb.Controllers
{
    public class EnderecoController : BaseController<Cidade>
    {
        public EnderecoController(IRepository<Cidade> repositoty) : base(repositoty)
        {
        }

        //[Authorize]
        [ResponseCache(Duration = 0)]
        public IActionResult GetListCidades(int idEstado)
        {
            var listacidades = _Repository.GetList(c => c.Estado.Id == idEstado);
            return PartialView("_ListaCidades", listacidades);
        }

        
    }
}