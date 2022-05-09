using System;

namespace SaintNickolas.EdibleGif
{
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
}
