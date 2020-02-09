namespace BeFaster.App.Solutions.CHK
{
    public class GroupOffer
    {
        public int Count { get; }
        public int SpecialPrice { get; }

        public GroupOffer(int count, int specialPrice)
        {
            this.Count = count;
            this.SpecialPrice = specialPrice;
        }
    }
}