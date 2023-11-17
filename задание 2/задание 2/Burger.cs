using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_2
{
    internal class Burger: Product
    {
        private List<Option> options = new List<Option>();
        private decimal basePrice;
        public Burger ( decimal basePrice, string name, string ImagePath) : base (basePrice, name, ImagePath) 
        { 
            this.basePrice = basePrice;
        }
        public override decimal GetPrice()
        {
            decimal price = basePrice;
            foreach (Option i in options)
            {
                price += i.Price;
            }
            return price;
        }
        public override string GetName () {
            return $"Бургер {Name}, цена: {GetPrice()}";
        }
        public void AddOption(Option option)
        {
            options.Add(option);
        }
        public void ClearOptions()
        {
            options.Clear();
        }
    }
}
