using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_2
{
    public class Order
    {
        private List<Product> products = new List<Product>();
        public int Number { get; set; }
        public DateTime OrderTime { get; set; }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public void Clear()
        {
            products.Clear();
        }
        public decimal TotalPrice()
        {
            decimal total = 0;
            foreach(var item in products)
            {
                total += item.GetPrice();
            }
            return total;
        }
        public int GetCount () {
            return products.Count();
        }
        public string GetCheck()
        {
            string Check = "Ваш заказ:\n";
            foreach(var item in products)
            {
                Check += $"{item.Name} цена: {item.GetPrice()}\n";
            }
            Check += $"полная стоимость заказа: {TotalPrice()}";
            return Check;
        }
    }
}
