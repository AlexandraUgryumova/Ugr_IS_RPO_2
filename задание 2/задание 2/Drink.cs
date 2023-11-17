using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_2
{
    internal class Drink : Product 
    {
        public int Volume { get; set; }
        public bool isBottled { get; set; }
        private decimal basePrice;
        public Drink(decimal basePrice, string Name, string ImagePath, int Volume) : base(basePrice, Name, ImagePath)
        {
            this.Volume = Volume;
            this.basePrice = basePrice;
        }
        public override decimal GetPrice()
        {
            decimal price = basePrice;
            if (isBottled)
            {
                price = basePrice + 25;
            }
            return price;
        }
        public override string GetName () {
            return $"Напиток {Name}, цена: {GetPrice()}";
        }
    }

}
