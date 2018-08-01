using System.Collections.Generic;

namespace CurrencyConverter.Models.ViewModels
{
    public class RickshawViewModel
    {
        public IEnumerable<string> Currencies { get; set; }
        public List<Vector2> CurrToGraph { get; set; }

        public RickshawViewModel()
        {

        }

        public class Vector2
        {
            public int X { get; set; }
            public decimal Y { get; set; }

            public Vector2(int x, decimal y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
