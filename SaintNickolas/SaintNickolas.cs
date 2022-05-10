using SaintNickolas.GiftFactory;
using System;
using System.Text;
using SaintNickolas.Iterator;

namespace SaintNickolas
{
    sealed class SaintNickolas
    {
        private ChildrensCollection childrenLetters = new ChildrensCollection();

        private static SaintNickolas _instance;

        private SaintNickolas()
        {
        }

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

        public void getLetterFromChildren(Children children)
        {
            IGiftFactory goodFactory = new GoodGiftsFactory();
            IGiftFactory badFactory = new BadGiftsFactory();

            children.setGiftFactory(
                children.getQuantityOfGoodDeeds() >= children.getQuantityOfBadDeeds()
                ? goodFactory
                : badFactory);

            childrenLetters.addItem(children);

            Console.WriteLine($"Лист від дитини з ім'ям {children.getFullName()} прийнято. Очікуйте подарунку!");
        }

        public void sendGifts()
        {
            Console.WriteLine("\n ***** Розсилання подарунків *****");

            Iterator.Iterator i = childrenLetters.createIterator();

            Children item = (Children)i.First();

            while (item != null)
            {
                Console.WriteLine("\nІнформація про дитину:\n" + item);
                item.getGiftFactory().createEdibleGift();
                item.getGiftFactory().createInedibleGift();
                item = (Children)i.Next();
            }
        }

        static void Main(string[] args)
        {
            Random random = new();

            SaintNickolas saintNickolas = new SaintNickolas();

            Children children1 = new Children("Васильченко", "Андрій", 15, 2);
            Children children2 = new Children("Роженко", "Анастасія", 8, 9);

            saintNickolas.getLetterFromChildren(children1);
            saintNickolas.getLetterFromChildren(children2);

            string[] surnames = { "Серниченко", "Стюарт", "Угрейчук", "Хом'як", "Лісак", "Лузійчук" };
            string[] names = { "Борис", "Вікторія", "Людмила", "Ігор", "Юлія", "Василь" };

            for (int i = 0; i < surnames.Length; i++)
            {
                saintNickolas.getLetterFromChildren(
                    new Children(
                        surnames[i],
                        names[i],
                        random.Next(3, 18),
                        random.Next(0, 8)));
            }

            saintNickolas.sendGifts();
        }
    }
}
