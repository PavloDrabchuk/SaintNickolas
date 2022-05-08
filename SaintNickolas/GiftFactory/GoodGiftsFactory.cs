using SaintNickolas.EdibleGif;
using SaintNickolas.InedibleGift;

namespace SaintNickolas.GiftFactory
{
    class GoodGiftsFactory : IGiftFactory
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
}
