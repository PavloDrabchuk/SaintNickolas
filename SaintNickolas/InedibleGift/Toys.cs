using System;

namespace SaintNickolas.InedibleGift
{
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
}
