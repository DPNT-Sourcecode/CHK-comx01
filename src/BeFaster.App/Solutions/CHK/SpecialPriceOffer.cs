namespace BeFaster.App.Solutions.CHK
{
    public class SpecialPriceOffer
    {
        public int Count { get; }
        public int SpecialPrice { get; }

        public SpecialPriceOffer(int count, int specialPrice)
        {
            this.Count = count;
            this.SpecialPrice = specialPrice;
        }
    }
}
