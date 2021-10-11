using kempsoft.Services.Price;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Controllers
{
    public class PriceController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


    }
}
