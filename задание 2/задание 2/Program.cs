using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace задание_2
{
    internal class Program
    {
        static bool answer = true;
        static Order orders = new Order();
        static List<Option> options = new List<Option>();
        static List<Product> products = new List<Product>();
        static Burger burger;
        static Option option;
        static Drink drink;
        static void Main(string[] args)
        {
            MainMenu();
        }
        static private void MainMenu () {
            answer = true;
            string numberVarios = "Выберите:\n 1. Создать товары.\n 2. Купить товары\n 3. Выписать чек\n 4. Выйти из программы";
            Console.WriteLine(numberVarios);
            while (answer) {
                switch (Console.ReadLine()) {
                    case "1":
                        Console.Clear();
                        MakeBurgerAndDrinkAndOption();
                        answer = false;
                        break;
                    case "2":
                        Console.Clear();
                        if (products.Count == 0) {
                            Console.WriteLine("Для выбора данного раздела отсутствуют товары. Сначала создайте их\n" + numberVarios);
                        } else {
                            BuyBurgerAndDrink();
                            answer = false;
                        }
                        break;
                    case "3":
                        if (orders.GetCount() == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("В чеке отсутствуют товары.Сначала выберте их из прайс-листа\n" + numberVarios);
                        }
                        else
                            Console.Clear();
                            Console.WriteLine(orders.GetCheck());
                        break;
                    case "4":
                        Console.WriteLine("Спасибо что воспользовались этой пограммой!");
                        Console.ReadKey();
                        answer = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Неверно введён ответ. Учитываются ответы только 1, 2 и 3\n" + numberVarios);
                        break;
                }
            }
        }
        static private void MakeBurgerAndDrinkAndOption () {
            answer = true;
            Console.WriteLine("Что вы хотите создать?\n 1. Бургер\n 2. Напиток\n 3. Опцию для бургера");
            while (answer) {
                switch (Convert.ToInt16(Console.ReadLine())) {
                    case 1:
                        Console.Clear();
                        MakeBurger();
                        answer = false;
                        break;
                    case 2:
                        Console.Clear();
                        MakeDrink();
                        answer = false;
                        break;
                    case 3:
                        Console.Clear();
                        MakeOption();
                        answer = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Неверно введён ответ. Учтываются ответы только 1, 2 и 3\nЧто вы хотите создать?\n 1. Бургер\n 2. Напиток\n 3. Опцию для бургера");
                        break;
                }
            }
        }
        static private void MakeBurger () {
            string name;
            string ImagePath;
            decimal basePrice;
            Console.WriteLine("Введите название бургера");
            name = Console.ReadLine();
            Console.WriteLine("Введите путь изображения бургера");
            ImagePath = Console.ReadLine();
            Console.WriteLine("Введите цену бургера");
            while (true) {
                string mess = Console.ReadLine();
                if (isDecimal(mess)) {
                    basePrice = Convert.ToDecimal(mess);
                    break;
                } else { Console.WriteLine("Некорреко ведена цена, попробуйте ещё раз."); }
            }
            burger = new Burger(basePrice, name, ImagePath);
            products.Add(burger);
            Console.WriteLine("Бургер успешно добавлен. Нажмите любую кнопку для выхода из раздела");
            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }

        static private void MakeDrink () {
            string name;
            string ImagePath;
            decimal basePrice;
            int volume;
            Console.WriteLine("Введите название напитка");
            name = Console.ReadLine();
            Console.WriteLine("Введите путь изображения напитка");
            ImagePath = Console.ReadLine();
            Console.WriteLine("Введите цену напитка");
            while (true) {
                string mess = Console.ReadLine();
                if (isDecimal(mess)) {
                    basePrice = Convert.ToDecimal(mess);
                    break;
                } else { Console.WriteLine("Некорреко ведена цена, попробуйте ещё раз."); }
            }
            Console.WriteLine("Введите объём напитка");
            while (true) {
                string mess = Console.ReadLine();
                if (isInt(mess)) {
                    volume = Convert.ToInt32(mess);
                    break;
                } else { Console.WriteLine("Некорреко ведена цена, попробуйте ещё раз."); }
            }
            drink = new Drink(basePrice, name, ImagePath, volume);
            products.Add(drink);
            Console.WriteLine("Напиток успешно добавлен. Нажмите любую кнопку для выхода из раздела");
            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }
        static private void MakeOption () {
            string name;
            decimal price;
            Console.WriteLine("Введите название опции");
            name = Console.ReadLine();
            Console.WriteLine("Введите цену опции");
            while (true) {
                string mess = Console.ReadLine();
                if (isDecimal(mess)) {
                    price = Convert.ToDecimal(mess);
                    break;
                } else { Console.WriteLine("Некорреко ведена цена, попробуйте ещё раз."); }
            }
            option = new Option(name, price);
            options.Add(option);
            Console.WriteLine("Опция успешно добавлена. Нажмите любую кнопку для выхода из раздела");
            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }
        static private void BuyBurgerAndDrink () {
            answer = true;
            int number=-1;
            int numberOption = -1;
            Burger burg;
            Console.WriteLine("что вы хотите добавить в заказ?");
            for(int i = 0; i < products.Count; i++) {
                Console.WriteLine($"{i}. {products[i].GetName()}");
            }
            Console.WriteLine("Введите номер товара");
            while (answer) {
                string n = Console.ReadLine();
                
                if (isInt(n)) {
                    number = Convert.ToInt32(n);
                    answer = false;
                }
                else
                {
                    Console.WriteLine("Номер товара введён неверно");
                }
            }
            Console.Clear();
            answer = true;
            if (isBurger(products[number]) && options.Count != 0)
            {
                burg = new Burger(products[number].GetPrice(), products[number].Name, products[number].ImagePath);
                while (answer)
                {
                    Console.WriteLine("Выберите опцию для бургера:");
                    for (int i = 0; i < options.Count; i++)
                    {
                        Console.WriteLine($"{i}. Опция: {options[i].Name}, Цена: {options[i].Price}.");
                    }
                    Console.WriteLine("Введите номер опции или выведите любой иной номер чтобы не выбирать опцию.");
                    try
                    {
                        numberOption = Convert.ToInt16(Console.ReadLine());

                        burg.AddOption(options[numberOption]);
                        Console.WriteLine("опция добавлена успешно. Вы хотите добавить ещё?\n 1. да\n 2. нет");
                        if (Console.ReadLine() == "1")
                        { }
                        else
                        {
                            answer = false;
                        }
                    }
                    catch { Console.WriteLine("опция для бургера не выбрана."); answer = false; }
                }
                orders.AddProduct(burg);
                Console.WriteLine("Вы успешно добавили товар " + burg.GetName());
            }
            else
            {
                orders.AddProduct(products[number]);
                Console.WriteLine("Вы успешно добавили товар " + products[number].GetName());
            }
            
            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }
        static private bool isBurger(object obj)
        {
            if(obj is Burger)
            {
                return true;
            }
            return false;
        }
        static private bool isDecimal(string message) {
            try {
                decimal a = Convert.ToDecimal(message);
                return true;
            } catch {
                return false;
            }
        }
        static private bool isInt (string message) {
            try {
                int a = Convert.ToInt32(message);
                return true;
            } catch {
                return false;
            }
        }
    }
}
