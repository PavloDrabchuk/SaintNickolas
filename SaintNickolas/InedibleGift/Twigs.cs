using System;

namespace SaintNickolas.InedibleGift
{
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
}
