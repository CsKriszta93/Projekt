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
            var rickshawViewModel = new RickshawViewModel();

            string[] colorlist = new string[] { "#c05020", "30c020", "6060c0", "red", "green", "blue", "yellow", "black", "white", "steelblue", "lightblue" };

            rickshawViewModel.Currencies = currencyContext.Currencies.Select(x => x.Currency).Distinct();

            rickshawViewModel.currencyGraph= new List<RickshawViewModel.CurrencyGraph>();

            int colorId = 0;

            foreach (var curr in rickshawViewModel.Currencies)
            {
                int id = 0;
                RickshawViewModel.CurrencyGraph graph = new RickshawViewModel.CurrencyGraph();
                graph.name = curr;
                graph.color = colorlist[colorId];

                foreach (var money in currencyContext.Currencies)
                {
                    if (money.Currency == curr)
                    {
                        graph.data.Add(new RickshawViewModel.Vector2(id, money.Rate));
                        id++;
                    }
                }
                    
                rickshawViewModel.currencyGraph.Add(graph);

                if (colorId < colorlist.Length - 1)
                {
                    colorId++;
                }               
            }

            return rickshawViewModel;
        }
    }
}


