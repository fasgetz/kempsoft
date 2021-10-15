using kempsoft.Models.DataBase;
using kempsoft.Models.ViewModels;
using kempsoft.Services.Price;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPriceService servicePrice;

        public PaymentController(IPriceService servicePrice)
        {
            this.servicePrice = servicePrice;
        }


        /// <summary>
        /// Страница оплаты
        /// </summary>
        /// <param name="idPrice">Тип товара</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult Index(int idPrice)
        {
            return View(idPrice);
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Fail()
        {
            return View();
        }
    }
}
