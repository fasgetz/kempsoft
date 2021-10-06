using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Controllers
{
    public class OfertaController : Controller
    {

        public IActionResult PrivacyDataOferta()
        {
            return View();
        }

        public IActionResult Oferta()
        {
            return View();
        }

    }
}
