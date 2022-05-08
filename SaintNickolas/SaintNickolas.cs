using System;
using System.Collections.Generic;
using System.Text;

namespace SaintNickolas
{
    public class Children
    {
        private string surname;
        private string name;
        private int quantityOfGoodDeeds;
        private int quantityOfBadDeeds;

        GiftFactory giftFactory;

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

        public GiftFactory getGiftFactory()
        {
            return giftFactory;
        }

        public void setGiftFactory(GiftFactory giftFactory)
        {
            this.giftFactory = giftFactory;
        }

        public string getFullName()
        {
            return surname + " " + name;
        }

        public override string ToString()
        {
            return $"Прізвище та ім'я: {getFullName()}. Кількість добрих справ: {quantityOfGoodDeeds}, кількість поганих справ: {quantityOfBadDeeds}.";
        }
    }

    public interface IEdibleGift
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



    public interface IInedibleGift
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

    public interface GiftFactory
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

    public abstract class Aggregate
    {
        public abstract Iterator createIterator();
    }

    public class ConcreteAggregate : Aggregate
    {
        List<Children> childrens = new();
        //List<GiftFactory> giftFactories = new();

        public override Iterator createIterator()
        {
            return new ConcreteIterator(this);
        }

        public int count
        {
            get { return childrens.Count; }
        }

        public Children this[int index]
        {
            get { return childrens[index]; }
            set { childrens.Insert(index, value); }
        }

        public void addItem(Children children)
        {
            this.childrens.Add(children);
        }

        public List<Children> getItems()
        {
            return childrens;
        }
    }

    public abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    public class ConcreteIterator : Iterator
    {
        ConcreteAggregate aggregate;
        int current = 0;

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        public override object CurrentItem()
        {
            return aggregate[current];
        }

        public override object First()
        {
            return aggregate[0];
        }

        public override bool IsDone()
        {
            return current >= aggregate.count;
        }

        public override object Next()
        {
            object ret = null;
            if (current < aggregate.count - 1)
            {
                ret = aggregate[++current];
            }

            return ret;
        }
    }


    sealed class SaintNickolas
    {
        //private List<Children> childrenLetters = new();
        ConcreteAggregate childrenLetters = new ConcreteAggregate();

        private SaintNickolas()
        {
        }

        private static SaintNickolas _instance;

        public static SaintNickolas GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SaintNickolas();
            }
            return _instance;
        }

        static SaintNickolas()
        {
            Console.OutputEncoding = Console.InputEncoding = Encoding.Unicode;
        }

        public void getLetter(Children children)
        {

            GiftFactory goodFactory = new GoodGiftsFactory();
            GiftFactory badFactory = new BadGiftsFactory();

            /*if (children.getQuantityOfGoodDeeds() >= children.getQuantityOfBadDeeds())
            {
                children.setGiftFactory(goodFactory);
            }
            else
            {
                children.setGiftFactory(badFactory);
            }*/

            children.setGiftFactory(
                children.getQuantityOfGoodDeeds() >= children.getQuantityOfBadDeeds()
                ? goodFactory
                : badFactory);

            childrenLetters.addItem(children);

            Console.WriteLine($"Лист від дитини з ім'ям {children.getFullName()} прийнято. Очікуйте подарунку!");
        }

        /*private void sendOneGift(int quantityOfGoodDeeds, int quantityOfBadDeeds)
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
        }*/

        public void sendGifts()
        {
            /*foreach (Children c in childrenLetters)
            {
                sendOneGift(c.getQuantityOfGoodDeeds(), c.getQuantityOfBadDeeds());
            }*/
            Iterator i = childrenLetters.createIterator();

            //Console.WriteLine("Iterating over collection:");

            Children item = (Children)i.First();

            while (item != null)
            {
                Console.WriteLine(item);
                item.getGiftFactory().createEdibleGift();
                item.getGiftFactory().createInedibleGift();
                item = (Children)i.Next();
            }
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            SaintNickolas saintNickolas = new SaintNickolas();

            Children children1 = new Children("Васильченко", "Андрій", 15, 2);
            Children children2 = new Children("Роженко", "Анастасія", 8,9);

            saintNickolas.getLetter(children1);
            saintNickolas.getLetter(children2);

            saintNickolas.sendGifts();
            /*saintNickolas.getOrder(12, 4);
            saintNickolas.getOrder(4, 14);
            saintNickolas.getOrder(12, 12);*/

            ///ConcreteAggregate a = new ConcreteAggregate();
            /*a[0] = children1;
            a[1] = children2;*/

            /*a.addItem(children1);
            a.addItem(children2);
            */



        }
    }
}
