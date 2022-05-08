using SaintNickolas.EdibleGif;
using SaintNickolas.InedibleGift;

namespace SaintNickolas.GiftFactory
{
    public interface IGiftFactory
    {
        public IEdibleGift createEdibleGift();

        public IInedibleGift createInedibleGift();
    }
}
