using CurrencyConverter.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CurrencyConverter.Controllers
{
    [Route("/rickshaw")]
    public class RickshawController : Controller
    {
        CurrencyRepository currencyRepository;

        public RickshawController(CurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }

        public IActionResult Index()
        {
            var currencies = currencyRepository.CurrenciesToChooseFrom();
            return View(currencies);
        }

        [HttpGet]
        public IActionResult Rickshaw()
        {
            var currencies = currencyRepository.CurrenciesToRickshawPage();
            return View(currencies);
        }
    }
}
