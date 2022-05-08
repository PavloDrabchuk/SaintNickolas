using System;

namespace SaintNickolas.EdibleGif
{
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
}
