using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrassaWeb.Models;
using DataRepository.Data;
using Microsoft.AspNetCore.Authorization;

namespace BrassaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Estado> _REstado;
		private readonly IRepository<Degustador> _RDegustador;

        public HomeController(IRepository<Estado> rEstado, IRepository<Degustador> rDegustador)
        {
            _REstado = rEstado;
			_RDegustador = rDegustador;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Política de privacidade.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Encontrar()
        {
            ViewBag.ListaEstados = _REstado.GetList();
            return View();
        }

        [Authorize]
		public IActionResult MeuBrassa()
		{
			var userName = User.Identity.Name;
			var degustador = _RDegustador.GetList(d => d.UserId.Equals(userName)).FirstOrDefault();
			if (degustador != null)
			{
				return RedirectToAction("MeuBrassa", "Degustador");
			}
			else            
			{
				return RedirectToAction("Index");
			}
		}
    }
}
