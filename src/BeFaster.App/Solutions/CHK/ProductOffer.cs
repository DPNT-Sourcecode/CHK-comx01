namespace BeFaster.App.Solutions.CHK
{
    public class ProductOffer
    {
        public int Count { get; }
        public int SpecialPrice { get; }

        public ProductOffer(int count, int specialPrice)
        {
            this.Count = count;
            this.SpecialPrice = specialPrice;
        }
    }
}