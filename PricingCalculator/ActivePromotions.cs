using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingCalculator
{
    class ActivePromotion
    {        
        public ActivePromotion(string skuId, int promationPrice, int quantity)
        {
            this.skuId = skuId;
            this.promationPrice = promationPrice;
            this.quantity = quantity;
        }

        public string skuId { get; set; }

        public int promationPrice { get; set; }

        public int quantity { get; set; }
    }
}
