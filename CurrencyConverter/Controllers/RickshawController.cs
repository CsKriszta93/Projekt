using CurrencyConverter.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CurrencyConverter.Controllers
{
    public class RickshawController : Controller
    {
        CurrencyRepository currencyRepository;

        public RickshawController(CurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/rickshaw")]
        [HttpGet]
        public IActionResult Rickshaw()
        {
            var currencies = currencyRepository.CurrenciesToRickshawPage();

            return View(currencies);
        }
    }
}
