namespace BeFaster.App.Solutions.CHK
{
    public class FreeProductOffer
    {
        public int Count { get; }
        public int FreeSku { get; }

        public FreeProductOffer(int count, char freeSku)
        {
            this.Count = count;
            this.FreeSku = freeSku;
        }
    }
}