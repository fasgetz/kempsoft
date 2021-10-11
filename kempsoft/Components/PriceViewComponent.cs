using kempsoft.Services.Price;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Components
{
    public class PriceViewComponent : ViewComponent
    {
        private readonly IPriceService priceService;

        public PriceViewComponent(IPriceService priceService)
        {
            this.priceService = priceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Models.DataBase.Price> prices = await priceService.getPricesAsync();

            return View(prices);
        }

    }
}
