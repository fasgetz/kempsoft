using kempsoft.Models.DataBase;
using kempsoft.Services.Price;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IPriceService servicePrice;

        public PriceController(IPriceService servicePrice)
        {
            this.servicePrice = servicePrice;
        }

        /// <summary>
        /// Получить прайс
        /// </summary>
        /// <param name="idPrice">Айди прайса</param>
        /// <returns>Прайс</returns>
        [HttpGet("getPrice")]
        public async Task<IActionResult> getPrice(int idPrice)
        {
            Price findPrice = await servicePrice.getPriceAsync(idPrice);

            // Если в бд не нашли прайс по айди, то выдать ошибку
            if (findPrice == null)
            {
                return BadRequest("Несуществующий прайс");
            }


            return Ok(findPrice);
        }
    }
}
