using CurrencyConverter.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Xml.Linq;

namespace CurrencyConverter.Models
{
    public class SeedData
    {
        private static readonly string currencyUrl = "http://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml";

        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var currencyContext = new CurrencyContext(serviceProvider.GetRequiredService<DbContextOptions<CurrencyContext>>()))
            {
                XDocument data = XDocument.Load(currencyUrl);
                XNamespace ns = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref";

                if (!currencyContext.Currencies.Any())
                {
                    var lv1s = from lv1 in data.Descendants(ns + "Cube")
                            .Where(x => x.Attribute("time") != null)
                               select new
                               {
                                   Time = Convert.ToDateTime(lv1.Attribute("time").Value),
                                   Children = lv1.Descendants(ns + "Cube")
                               };

                    foreach (var lv1 in lv1s)
                    {
                        foreach (var lv2 in lv1.Children)
                        {
                            Money money = new Money
                            {
                                Time = lv1.Time,
                                Currency = (string)lv2.Attribute("currency"),
                                Rate = (decimal)lv2.Attribute("rate")
                            };

                            currencyContext.Currencies.Add(money);
                            currencyContext.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
