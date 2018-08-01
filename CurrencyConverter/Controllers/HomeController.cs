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
            var result = currencyRepository.CalculateAmount(amount, idFrom, idTo);

            if (ModelState.IsValid)
            {
                var viewModel = new CurrencyFormViewModel
                {
                    Amount = amount,
                    Result = result
                };

                return RedirectToAction("Index", viewModel);
            }

            return NotFound();           
        }
    }
}
