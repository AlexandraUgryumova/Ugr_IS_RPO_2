using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_2
{
    abstract public class Product
    {
        private decimal basePrice;
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public Product(decimal basePrice, string name, string ImagePath)
        {
            this.basePrice = basePrice;
            this.Name = name;
            this.ImagePath = ImagePath;
        }
        public abstract decimal GetPrice();
        public abstract string GetName ();
    }
}
