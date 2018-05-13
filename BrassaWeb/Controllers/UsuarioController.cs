using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrassaWeb.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        public IActionResult MeuBrassa()
        {
            return View();
        }
    }
}