using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    public class RepActivosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
