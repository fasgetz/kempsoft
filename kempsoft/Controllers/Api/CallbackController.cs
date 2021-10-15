using kempsoft.Services.SberbankService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Controllers.Api
{

    /// <summary>
    /// CallBack контроллер для 
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class CallbackController : ControllerBase
    {
        private readonly ISberbankService sberbankService;

        public CallbackController(ISberbankService sberbankService)
        {
            this.sberbankService = sberbankService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string mdOrder, string orderNumber, string operation, byte status)
        {
            bool successPayment = await sberbankService.checkSuccessPayment(mdOrder);


            System.IO.File.AppendAllText("test.txt", $"{DateTime.Now} | {mdOrder} | {orderNumber} | {operation} | {status} | вызван метод контроллера! | successPayment: {successPayment}" + Environment.NewLine);

            return Ok($"{DateTime.Now} success writed!");
        }
    }
}
