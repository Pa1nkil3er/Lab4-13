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
            Chef chef = new Chef(regworker, midworker);
            Dialogues dialouges = new Dialogues(waiter);
            dialouges.Welcome();
            dialouges.Ask1();
            PizzaName pizzaname = dialouges.Answer1();// в цьому рядку зберігаємо назву піци
            waiter.Order(pizzaname);
            chief.Choose();

            //передаємо офіціанту
            //punct = Convert.ToInt32(Console.ReadLine());


        }
    }


    abstract class Person
    {
        #region Enum
        enum Names
        {
            Михайло,
            Кирило,
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
        public double experience;

    }
    class Waiter : Employer
    {
        #region Construct
        public Waiter() { }

        #endregion
        #region Methods
        public void Order(PizzaName pizzaname)
        {
            Random rnd = new Random();
            int delay = rnd.Next(5000, 15000);
            switch (pizzaname)
            {
                case PizzaName.Hawaaian:
                    Console.WriteLine($"Ваше замовлення:Гавайська пiца вагою {HawaiianPizza.Weight},сума до сплати {HawaiianPizza.Price} грн  ");
                    break;
                case PizzaName.Carbonara:
                    Console.WriteLine($"Ваше замовлення:Пiца карбонара вагою {CarbonaraPizza.Weight},сума до сплати {CarbonaraPizza.Price} грн  ");
                    break;
                case PizzaName.WithMushrooms:
                    Console.WriteLine($"Ваше замовлення:Пiца з грибами вагою {MushroomPizza.Weight},сума до сплати {MushroomPizza.Price} грн  ");
                    break;
            }
            Console.WriteLine("Передаю ваше замовлення");
            Thread.Sleep(delay);
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
            return (PizzaName)Convert.ToInt32(Console.ReadLine());
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
            experience = rnd.Next(4, 10);
        }
        #endregion

        #region Methods
        public void TakeOrder(PizzaName pizzaname)
        {
            Random rnd = new Random();
            int delay = rnd.Next(1000, 2000);
            Console.WriteLine($"Шеф {Name} отримав ваше замовлення, а саме {pizzaname} ");
            Thread.Sleep(delay);
            _ordername = pizzaname;
        }
        public Pizza Choose()
        {
            int delay = rnd.Next(2000, 4000);
            Console.WriteLine("Шеф розподiляє, кому доведеться зробити вашу пiцу");
            switch (_ordername)
            {
                case PizzaName.Hawaaian:
                    Console.WriteLine($"Вашим замовленням буде займатися сам Шеф {Name}, який вже працює в цьому залкаді" +
                        $" {experience} років ");
                    break;
                case PizzaName.Carbonara:
                    Console.WriteLine($"Вашим замовлення буде займатися працівник {_midWorker.Name}, який вже працює в цьому закладі" +
                        $" {_midWorker.experience} ");
                    return _midWorker.LetsArbaiten(_ordername);//зробити цей метод в класі працівник, в методі арбайтен ми описуємо процес приготування піци
                    // 
                    break;
                case PizzaName.WithMushrooms:
                    Console.WriteLine($"Вашим замовлення буде займатися працівник {_regWorker.Name}, який вже працює в цьому закладі" +
                       $" {_regWorker.experience} ");
                    break;
            }
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
        public static int Weight { get; set; }
        public static int Price { get; set; }
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
