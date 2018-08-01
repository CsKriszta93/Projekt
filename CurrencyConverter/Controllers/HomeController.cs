using CurrencyConverter.Models.ViewModels;
using CurrencyConverter.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CurrencyConverter.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        CurrencyRepository currencyRepository;

        public HomeController(CurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var currencies = currencyRepository.CurrenciesToChooseFrom();
            var viewModel = new CurrencyFormViewModel
            {
                Currencies = currencies,
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(decimal amount, int idFrom, int idTo)
        {
            var currencies = currencyRepository.CurrenciesToChooseFrom();
            var fromCurr = currencyRepository.GetCurrencyById(idFrom);
            var toCurr = currencyRepository.GetCurrencyById(idTo);
            var result = currencyRepository.CalculateAmount(amount, idFrom, idTo);

            if (ModelState.IsValid)
            {
                var viewModel = new CurrencyFormViewModel()
                {
                    Currencies = currencies,
                    FromCurrId = idFrom,
                    ToCurrId = idTo,
                    Amount = amount,
                    Result = result
                };

                return View("Index", viewModel);
            }

            return NotFound();
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
