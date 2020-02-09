using System.Collections.Generic;

namespace BeFaster.App.Solutions.CHK
{
    public class GroupOffer
    {
        public List<char> Skus { get; }
        public int SpecialPrice { get; }

        public GroupOffer(List<char> skus, int specialPrice)
        {
            this.Skus = skus;
            this.SpecialPrice = specialPrice;
        }
    }
}