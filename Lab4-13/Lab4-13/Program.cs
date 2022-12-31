using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lab5
{
    public enum PizzaName
    {
        Carbonara,
        WithMushrooms,
        Hawaaian,
    }

    class Program
    {
        static void Main(string[] args) // Point of enter
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            RegWorker regworker = new RegWorker();
            MidWorker midworker = new MidWorker();
            Chef chef = new Chef(regworker, midworker);
            Dialogues dialouges = new Dialogues(waiter);
            dialouges.Begin();
            dialouges.Welcome();
            dialouges.Ask1();
            PizzaName pizzaname = dialouges.Answer1();// в цьому рядку зберігаємо назву піци
            waiter.Order(pizzaname);
            chef.TakeOrder(pizzaname);
            Pizza pizza = chef.Choose();
            waiter.Return(pizza);
            customer.Eat(pizza);
            waiter.Check(pizza);
            customer.Pay(pizza);
            //передаємо офіціанту
            //punct = Convert.ToInt32(Console.ReadLine());


        }
    }


    abstract class Person
    {
        #region Properties
        public Random _rnd = new Random();
        public int _delay;
        #endregion
        #region Construct
        public Person()
        {
        }
        #endregion
    }

    class Customer : Person
    {
        public string name = "Кирило";
        public int Money = 700;
        #region Methods
        public void Eat(Pizza pizza)
        {
            Console.WriteLine($"{name} їсть... ");
            Thread.Sleep(_delay = _rnd.Next(3000, 6000));
        }
        public void Pay()
        {
            Console.WriteLine($"У {name} в гаманці {Money} гривень");
        }
        public void Pay(Pizza pizza)
        {
            Console.WriteLine($"{name} заплатив {pizza.Price} гривень");
            Money = Money - pizza.Price;
            Thread.Sleep(2500);
            Console.WriteLine($"У {name} залишилося {Money} гривень");
        }
        #endregion
    }
    abstract class Employer : Person
    {
        #region Enum
        enum Names
        {
            Михайло,
            Данило,
            Iлля,
            Володимир,
            Олександр,
            Олександра,
            Петро,
            Борис,
            Алiна,
            Софiя,
            Людмила,
            Єлизавета,
            Анастасiя,
            Роман,
            Юра,
            Бен,
            Едуард,
            Тетяна,
            Денис,
            Вадим,
            Мотря
        }
        #endregion
        public double experience;
        public string Name = "";
        public Employer()
        {
            Random rnd = new Random();
            var names = (Names)rnd.Next(0, 20);
            Name = names.ToString();
        }
        public Pizza LetsWork(PizzaName _ordername)
        {
            Thread.Sleep(_delay = _rnd.Next(3000, 5000));
            switch (_ordername)
            {
                case PizzaName.Hawaaian:
                    HawaiianPizza hawaiianpizza = new HawaiianPizza();
                    Console.WriteLine($"Працівник замішує тісто, ложить багато томатного соусу, добавляє ананаси, курку, кукурудзу та посипає це все сиром моцарелла ");
                    Thread.Sleep(_delay = _rnd.Next(5000, 7000));
                    return hawaiianpizza;
                case PizzaName.Carbonara:
                    CarbonaraPizza carbonaraPizza = new CarbonaraPizza();
                    Console.WriteLine($"Працівник замішує тісто, ложить багато соусу альфредо, додає цибулю, халапеньо, оливки, помідори, а також бекон");
                    Thread.Sleep(_delay = _rnd.Next(5000, 7000));
                    return carbonaraPizza;
                case PizzaName.WithMushrooms:
                    MushroomPizza mushroomPizza = new MushroomPizza();
                    Console.WriteLine($"Працівник замішує тісто, ложить багато томатного соусу, додає печериці, помідори, солониі огіргки, а також посипає твердим сиром ");
                    Thread.Sleep(_delay = _rnd.Next(5000, 7000));
                    return mushroomPizza;
                default:
                    return null;

            }
        }
    }
    class Waiter : Employer
    {

        #region Construct
        public Waiter() { }

        #endregion
        #region Methods
        public void Order(PizzaName pizzaname)
        {
            Pizza _pizza;
            _delay = _rnd.Next(3000, 5000);
            switch (pizzaname)
            {
                case PizzaName.Hawaaian:
                    _pizza = new HawaiianPizza();
                    Console.WriteLine($"Ваше замовлення:Гавайська пiца вагою {_pizza.Weight} грам,сума до сплати:{_pizza.Price} грн");
                    break;
                case PizzaName.Carbonara:
                    _pizza = new CarbonaraPizza();
                    Console.WriteLine($"Ваше замовлення:Пiца карбонара вагою {_pizza.Weight} грам,сума до сплати:{_pizza.Price} грн");
                    break;
                case PizzaName.WithMushrooms:
                    _pizza = new MushroomPizza();
                    Console.WriteLine($"Ваше замовлення:Пiца з грибами вагою {_pizza.Weight} грам,сума до сплати:{_pizza.Price} грн");
                    break;
            }
            Console.WriteLine("Передаю ваше замовлення");
            Thread.Sleep(_delay = _rnd.Next(3000, 8000));
        }
        public Pizza Return(Pizza pizza)
        {
            Console.WriteLine($"Офіціант {Name} несе вам вашу піцу");
            Thread.Sleep(_delay = _rnd.Next(3000, 8000));
            return pizza;
        }
        public void Check(Pizza pizza)
        {
            Console.WriteLine($"З вас до сплати {pizza.Price} гривень");
            Thread.Sleep(_delay = _rnd.Next(2000, 4500));
        }
        #endregion

    }
    class Dialogues
    {
        public void Begin()
        {
            Customer customer = new Customer();
            Console.WriteLine($"{customer.name} заходить в піцерію, у нього в гаманці {customer.Money} гривень");
        }
        Waiter _waiter;
        public Dialogues(Waiter waiter)
        {
            _waiter = waiter;
        }
        public void Welcome()
        {
            Random rnd = new Random();
            int delay = rnd.Next(1000, 5000);
            Thread.Sleep(delay);
            Console.WriteLine($"Добрий день, мене звати {_waiter.Name}, " +
                $"сьогоднi я буду вас обслуговувати, " +
                $"давайте пройдемо за столик");
            Thread.Sleep(delay);
        }
        public void Ask1()
        {
            Console.WriteLine("У нас в меню є 3 види пiци:");
            Console.WriteLine("1. Пiца карбонара");
            Console.WriteLine("2. Пiца з грибами");
            Console.WriteLine("3. Гавайська пiца");

        }
        public PizzaName Answer1()
        {
            int index = int.Parse(Console.ReadLine()) - 1;
            return (PizzaName)index;
        }

    }
    class Chef : Employer // Реалізувати патерн одинак в цьому класі(((
    {
        PizzaName _ordername;
        RegWorker _regWorker;
        MidWorker _midWorker;
        #region Construct
        public Chef(RegWorker regworker, MidWorker midWorker)
        {
            _regWorker = regworker;
            _midWorker = midWorker;
            experience = _rnd.Next(6, 10);
        }
        #endregion

        #region Methods
        public void TakeOrder(PizzaName pizzaname)
        {
            string pname = "";
            switch (pizzaname)
            {
                case PizzaName.Hawaaian:
                    pname = "гавайська піца";
                    break;
                case PizzaName.Carbonara:
                    pname = "піца карбонара";
                    break;
                case PizzaName.WithMushrooms:
                    pname = "грибна піца";
                    break;
            }


            Console.WriteLine($"Шеф {Name} отримав ваше замовлення, а саме {pname}");
            Thread.Sleep(_delay = _rnd.Next(1000, 3000));
            _ordername = pizzaname;
        }
        public Pizza Choose()
        {

            Console.WriteLine("Шеф розподiляє, кому доведеться зробити вашу пiцу");
            _delay = _rnd.Next(2500, 4000);
            switch (_ordername)
            {
                case PizzaName.Hawaaian:
                    _delay = _rnd.Next(1500, 2500);
                    Console.WriteLine($"Вашим замовленням буде займатися сам Шеф {Name}, який вже працює в цьому закладі" +
                        $" {experience} років");
                    return LetsWork(_ordername);
                case PizzaName.Carbonara:
                    _delay = _rnd.Next(1500, 2500);
                    Console.WriteLine($"Вашим замовлення буде займатися працівник {_midWorker.Name}, який вже працює в цьому закладі" +
                        $" {_midWorker.experience} років");
                    return _midWorker.LetsWork(_ordername);
                case PizzaName.WithMushrooms:
                    _delay = _rnd.Next(1500, 2500);
                    Console.WriteLine($"Вашим замовлення буде займатися працівник {_regWorker.Name}, який вже працює в цьому закладі" +
                       $" {_regWorker.experience} років");
                    return _regWorker.LetsWork(_ordername);
                default:
                    return null;
            }
        }
        #endregion
    }
    class RegWorker : Employer
    {
        #region Construct
        public RegWorker()
        {
            experience = _rnd.Next(1, 2);
        }
        #endregion
    }
    class MidWorker : Employer
    {
        #region Construct
        public MidWorker()
        {
            experience = _rnd.Next(3, 5);
        }
        #endregion
    }
    abstract class Pizza
    {
        #region Properties
        public int Weight { get; set; }
        public int Price { get; set; }
        //protected List<string> Ingredients = new List<string> {"Тiсто"};
        #endregion
        public Pizza()
        { }

    }
    class MushroomPizza : Pizza
    {
        #region Construct
        public MushroomPizza()
        {
            Price = 180;
            Weight = 320;
            //Ingredients.AddRange(new List<string> { "Cheese", "Mushroom", "Sausages" });
        }
        #endregion
        #region Methods
        //public void ReturnInfo(out int price, out double weight)
        //{
        //    price = Price;
        //    weight = Weight;
        //}
        #endregion 

    }
    class CarbonaraPizza : Pizza
    {
        #region Construct
        public CarbonaraPizza()
        {
            Price = 220;
            Weight = 450;
            //Ingredients.AddRange(new List<string> { "Цибуля","Халапеньо","Оливки","Помідори","Бекон", "Соус Альфредо" });
        }
        #endregion
    }
    class HawaiianPizza : Pizza
    {
        #region Construct
        public HawaiianPizza()

        {
            Price = 320;
            Weight = 540;
            //Ingredients.AddRange(new List<string> { "Ham", "Pineapple", "Roasted red peppers", "Mozarella" });
        }
        #endregion
    }

}
