using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_2
{
    public class Option
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Option(string name, decimal price) {
            this.Name = name;
            this.Price = price;
        }
    }
}
