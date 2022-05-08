using SaintNickolas.EdibleGif;
using SaintNickolas.InedibleGift;

namespace SaintNickolas.GiftFactory
{
    class BadGiftsFactory : IGiftFactory
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
}
