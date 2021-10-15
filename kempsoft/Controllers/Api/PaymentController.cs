using kempsoft.Models.ViewModels;
using kempsoft.Services.SberbankService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Controllers.Api
{

    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ISberbankService sberService;

        public PaymentController(ISberbankService sberService)
        {
            this.sberService = sberService;
        }

        [Authorize]
        [HttpPost("Pay")]
        public async Task<IActionResult> Pay(PaymentForm model)
        {
            try
            {
                // Получаем url платежа
                string url = await sberService.createOrder(model, User.Identity.Name);

                return Ok(url);
            }
            // В случае ошибки на стороне сервера при создании платежа возвращаем ее
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
