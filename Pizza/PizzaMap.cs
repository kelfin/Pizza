using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza
{
    public class PizzaMap
    {
        public int ID { set; get; }
        public int TeamId { set; get; }
        public IEnumerable<int> PizzaOption { set; get; }
    }
}
