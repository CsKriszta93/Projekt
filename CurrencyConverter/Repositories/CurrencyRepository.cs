using CurrencyConverter.Entities;
using CurrencyConverter.Models;
using CurrencyConverter.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter.Repositories
{
    public class CurrencyRepository
    {
        CurrencyContext currencyContext;

        public CurrencyRepository(CurrencyContext currencyContext)
        {
            this.currencyContext = currencyContext;
        }

        public List<Money> CurrenciesToChooseFrom()
        {
            var currencies = (from curr in currencyContext.Currencies
                              let MaxDate = (from date in currencyContext.Currencies
                                            select date.Time).Max()
                                  where curr.Time == MaxDate
                                  select curr).ToList();
                return currencies;
        }

        public decimal CalculateAmount(decimal amount, int idFrom, int idTo)
        {
            decimal result = 0;

            Money fromCurr = GetCurrencyById(idFrom);
            Money toCurr = GetCurrencyById(idTo);

            if (amount == 0)
            {
                return 0;
            }
            else
            {
                return result += (amount / fromCurr.Rate) * toCurr.Rate;
            }
        }

        public Money GetCurrencyById(int currId)
        {
            Money selectedCurr = currencyContext.Currencies.FirstOrDefault(c => c.Id == currId);

            return selectedCurr;
        }

        public List<Money> GetAllCurrencies()
        {
            var currencies = (from curr in currencyContext.Currencies
                         select curr).ToList();

            return currencies;
        }

        public RickshawViewModel CurrenciesToRickshawPage()
        {
            RickshawViewModel rickshawViewModel = new RickshawViewModel();

            rickshawViewModel.Currencies = currencyContext.Currencies.Select(x => x.Currency).Distinct();
            rickshawViewModel.CurrToGraph = new List<RickshawViewModel.Vector2>();

            int id = 0;
            foreach (var curr in currencyContext.Currencies)
                if (curr.Currency == "USD")
                {
                    rickshawViewModel.CurrToGraph.Add(new RickshawViewModel.Vector2(id, curr.Rate * 10));
                    id++;
                }

            return rickshawViewModel;
        }
    }
}


