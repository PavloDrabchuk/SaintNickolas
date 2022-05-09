using SaintNickolas.GiftFactory;

namespace SaintNickolas
{
    public class Children
    {
        private string surname;
        private string name;
        private int quantityOfGoodDeeds;
        private int quantityOfBadDeeds;

        private IGiftFactory giftFactory;

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

        public string getSurname()
        {
            return surname;
        }

        public void setSurname(string surname)
        {
            this.surname = surname;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
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

        public IGiftFactory getGiftFactory()
        {
            return giftFactory;
        }

        public void setGiftFactory(IGiftFactory giftFactory)
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
}
