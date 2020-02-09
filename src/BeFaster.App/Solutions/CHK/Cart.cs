﻿using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    public class Cart
    {
        public string skus { get; }

        public Cart(string skus)
        {
            this.skus = skus;
        }

        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(skus);
        }

        public bool HasInvalidProduct(List<Product> allowedProducts)
        {
            for (var skuCount = 0; skuCount < skus.Length; skuCount++)
            {
                var currentSku = allowedProducts.FirstOrDefault(p => p.Sku == skus[skuCount]);
                if (currentSku == null)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetTotalPrice(List<Product> allowedProducts)
        {
            var basketTotal = 0;
            var uniqueSkus = skus.Distinct().ToList();

            for (var skuCount = 0; skuCount < uniqueSkus.Count(); skuCount++)
            {
                var currentSku = allowedProducts.First(p => p.Sku == uniqueSkus[skuCount]);
                basketTotal += currentSku.GetPrice(skus);
            }

            return basketTotal;
        }
    }
}