using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingCalculator
{
    class Product
    {
        public Product(string skuId, int price)
        {
            this.skuId = skuId;
            this.price = price;
        }

        public string skuId { get; set; }

        public int price { get; set; }        
    }
}
