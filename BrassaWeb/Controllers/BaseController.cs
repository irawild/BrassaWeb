using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataRepository.Data;
using Microsoft.AspNetCore.Mvc;

namespace BrassaWeb.Controllers
{
    public class BaseController<T> : Controller where T : class
    {
        protected IRepository<T> _Repository;

        public BaseController(IRepository<T> repositoty)
        {
            _Repository = repositoty;
        }

    }
}