using System.Collections.Generic;

namespace CurrencyConverter.Models.ViewModels
{
    public class RickshawViewModel
    {
        public IEnumerable<string> Currencies { get; set; }
        public List<CurrencyGraph> currencyGraph;

        public RickshawViewModel()
        {

        }

        public class CurrencyGraph
        {
            public CurrencyGraph()
            {
                data = new List<Vector2>();
            }

            public string name;
            public string color;
            public List<Vector2> data { get; set; }
        }

        public class Vector2
        {
            public Vector2(int x, decimal y)
            {
                this.x = x;
                this.y = y;
            }

            public int x { get; set; }
            public decimal y { get; set; }
        }       
    }
}

