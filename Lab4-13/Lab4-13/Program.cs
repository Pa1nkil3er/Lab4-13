using System;
using System.Collections.Generic;
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
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            RegWorker regworker = new RegWorker();
            MidWorker midworker = new MidWorker();
            Chef chef = new Chef();
            Dialogues dialouges = new Dialogues(waiter);
            dialouges.Welcome();
            dialouges.Ask1();
            PizzaName pizzaname = dialouges.Answer1();// в цьому рядку зберігаємо назву піци
            
            //передаємо офіціанту
            //punct = Convert.ToInt32(Console.ReadLine());


        }
    }


    abstract class Person
    {
        #region Enum
        enum Names
        {
            Jack,
            John,
            Jason,
            Peter,
            Tom,
            Rick,
            Charles,
            Mark,
            Edvard,
            Richard,
            Elon,
            Isaac,
            Lisa,
            Sophia,
            Mia,
            Charlotte,
            Emma,
            Olivia,
            Isabella,
            Camila,
            Emily
        }
        #endregion
        #region Properties
        protected int Age;
        public string Name { get; set; }
        Random rnd = new Random();
        #endregion
        #region Construct
        public Person()
        {
            Random rnd = new Random();
            var names = (Names)rnd.Next(0, 20);
            Name = names.ToString();
            Age = rnd.Next(18, 45);

        }
        #endregion
    }

    class Customer : Person
    {
        public int Money { get; set; }
    }
    abstract class Employer : Person
    {
        protected Random rnd = new Random();
        protected double experience;

    }
    class Waiter : Employer
    {
        #region Construct
        public Waiter() { }

        #endregion
        #region Methods
        public void Order(PizzaName pizzaname)
        {
            MushroomPizza mushroomPizza = new MushroomPizza();
            HawaiianPizza hawaiianPizza = new HawaiianPizza();
            CarbonaraPizza carbonaraPizza = new CarbonaraPizza();   
            switch (pizzaname)
            {
                case PizzaName.Hawaaian:
                    Console.WriteLine($"Ваше замовлення:Гавайська піцца вагою {hawaiianPizza.Weight},сума до сплати {hawaiianPizza.Price} грн  ");
                    break;
                case PizzaName.Carbonara:
                     Console.WriteLine($"Ваше замовлення:Гавайська піцца вагою {carbonaraPizza.Weight},сума до сплати {carbonaraPizza.Price} грн  ");
                    break;
            }
            
        }
        #endregion
    }
    class Dialogues
    {
        Waiter _waiter;
        public Dialogues(Waiter waiter)
        {
            _waiter = waiter;
        }
        public void Welcome()
        {
            Random rnd = new Random();
            int delay = rnd.Next(1000, 5000);
            Console.WriteLine($"Добрий день, мене звати {_waiter.Name}, " +
                $"сьогодні я буду вас обслуговувати, " +
                $"давайте пройдемо за столик");
            Thread.Sleep(delay);
        }
        public void Ask1()
        {
            Console.WriteLine("У нас в меню є 3 види піци:");
            Console.WriteLine("1. Піца карбонара");
            Console.WriteLine("2. Піца з грибами");
            Console.WriteLine("3. Гавайська піца");


        }
        public PizzaName Answer1()
        {
            return (PizzaName)Convert.ToInt32(Console.ReadLine());
        }

    }
    class Chef : Employer
    {
        #region Construct
        public Chef()
        {
            experience = rnd.Next(4, 10);
        }
        #endregion
    }
    class RegWorker : Employer
    {
        #region Construct
        public RegWorker()
        {
            experience = rnd.Next(0, 2);
        }
        #endregion
    }
    class MidWorker : Employer
    {
        #region Construct
        public MidWorker()
        {
            experience = rnd.Next(3, 5);
        }
        #endregion
    }
    abstract class Pizza
    {
        #region Properties
        public int Weight { get; set; }
        public int Price { get; set; }
        protected List<string> Ingredients = new List<string> { "Dough", "Tomato souce" };
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
            Ingredients.AddRange(new List<string> { "Cheese", "Mushroom", "Sausages" });
        }
        #endregion
        #region Methods
        public void ReturnInfo(out int price, out double weight)
        {
            price = Price;
            weight = Weight;
        }
        #endregion 

    }
    class CarbonaraPizza : Pizza
    {
        #region Construct
        public CarbonaraPizza()
        {
            Price = 220;
            Weight = 450;
            Ingredients.AddRange(new List<string> { "Garlic", "Black pepper", "Runny egs" });
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
            Ingredients.AddRange(new List<string> { "Ham", "Pineapple", "Roasted red peppers", "Mozarella" });
        }
        #endregion
    }

}



