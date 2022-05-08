using System;
using System.Collections.Generic;
using System.Text;

namespace SaintNickolas
{
    class Children
    {
        private string surname;
        private string name;
        private int quantityOfGoodDeeds;
        private int quantityOfBadDeeds;

        public Children()
        {
        }

        public Children(string surname, string name, int quantityOfGoodDeeds, int quantityOfBadDeeds)
        {
            this.surname = surname;
            this.name = name;
            this.quantityOfGoodDeeds = quantityOfGoodDeeds;
            this.quantityOfBadDeeds = quantityOfBadDeeds;
        }

        public int getQuantityOfGoodDeeds()
        {
            return quantityOfGoodDeeds;
        }

        public void setQuantityOfGoodDeeds(int q)
        {
            this.quantityOfGoodDeeds = q;
        }

        public int getQuantityOfBadDeeds()
        {
            return quantityOfBadDeeds;
        }

        public void setQuantityOfBadDeeds(int q)
        {
            this.quantityOfBadDeeds = q;
        }

        public string getFullName()
        {
            return surname + " " + name;
        }

    }

    interface IEdibleGift
    {
        public void display();
    }

    class Sweets : IEdibleGift
    {
        public Sweets()
        {
            Console.WriteLine("Добрий їстівний подарунок: солодощі.");
        }

        public void display()
        {
            Console.WriteLine("Солодощі.");
        }
    }

    class BitterPills : IEdibleGift
    {
        public BitterPills()
        {
            Console.WriteLine("Поганий їстівний подарунок: гіркі пілюлі.");
        }

        public void display()
        {
            Console.WriteLine("Гіркі пілюлі.");
        }
    }



    interface IInedibleGift
    {
        public void display();

    }

    class Toys : IInedibleGift
    {
        public Toys()
        {
            Console.WriteLine("Добрий неїстівний подарунок: іграшки.");
        }

        public void display()
        {
            Console.WriteLine("Іграшки.");
        }
    }

    class Twigs : IInedibleGift
    {
        public Twigs()
        {
            Console.WriteLine("Поганий неїстівний подарунок: різки.");
        }

        public void display()
        {
            Console.WriteLine("Різки.");
        }
    }

    interface GiftFactory
    {
        public IEdibleGift createEdibleGift();

        public IInedibleGift createInedibleGift();
    }

    class GoodGiftsFactory : GiftFactory
    {
        public IEdibleGift createEdibleGift()
        {
            return new Sweets();
        }

        public IInedibleGift createInedibleGift()
        {
            return new Toys();
        }
    }

    class BadGiftsFactory : GiftFactory
    {
        public IEdibleGift createEdibleGift()
        {
            return new BitterPills();
        }

        public IInedibleGift createInedibleGift()
        {
            return new Twigs();
        }
    }
    class SaintNickolas
    {
        private List<Children> childrenLetters = new();
        public SaintNickolas()
        {
        }

        static SaintNickolas()
        {
            Console.OutputEncoding = Console.InputEncoding = Encoding.Unicode;
        }

        public void getOrder(Children children)
        {
            childrenLetters.Add(children);
            Console.WriteLine($"Лист від дитини з ім'ям {children.getFullName()} прийнято. Очікуйте подарунку!");
        }

        private void sendOneGift(int quantityOfGoodDeeds, int quantityOfBadDeeds)
        {
            GiftFactory goodFactory = new GoodGiftsFactory();
            GiftFactory badFactory = new BadGiftsFactory();

            if (quantityOfGoodDeeds >= quantityOfBadDeeds)
            {
                // Фабрика добрих подарунків
                Console.WriteLine("Good");
                goodFactory.createEdibleGift();
                goodFactory.createInedibleGift();
            }
            else
            {
                // Фабрика поганих подарунків
                Console.WriteLine("Not good");
                badFactory.createEdibleGift();
                badFactory.createInedibleGift();
            }
        }

        public void sendGifts()
        {
            foreach (Children c in childrenLetters)
            {
                sendOneGift(c.getQuantityOfGoodDeeds(), c.getQuantityOfBadDeeds());
            }
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            SaintNickolas saintNickolas = new SaintNickolas();

            Children children1 = new Children("Васильченко", "Андрій", 15, 2);
            Children children2 = new Children("Роженко", "Анастасія", 8, 8);

            saintNickolas.getOrder(children1);
            saintNickolas.getOrder(children2);

            saintNickolas.sendGifts();
            /*saintNickolas.getOrder(12, 4);
            saintNickolas.getOrder(4, 14);
            saintNickolas.getOrder(12, 12);*/
        }
    }
}
