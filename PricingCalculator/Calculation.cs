using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingCalculator
{
    class Calculation
    {
        int indProddisct;
        int combooffers;
        public int calculatePrdodDis(List<Product> products, List<ActivePromotion> activePromotions, List<PurchaseOrder> purchaseOrders)
        {
            combooffers = calculateCombooffers(products, activePromotions, purchaseOrders);
            indProddisct = calculateIndPrdodDis(products, activePromotions, purchaseOrders);            
            return indProddisct + combooffers;
        }
        public int calculateIndPrdodDis(List<Product> products, List<ActivePromotion> activePromotions, List<PurchaseOrder> purchaseOrders)
        {
            int proddisc=0;
            foreach (var purchaseprod in purchaseOrders)
            {
                var activpromoPord = activePromotions.Find(x => x.skuId == purchaseprod.skuId);                
                var purchaseActProd = products.Find(x => x.skuId == purchaseprod.skuId);
                if (activpromoPord == null)
                {
                    proddisc += (purchaseprod.quantity * purchaseActProd.price);
                }
                else
                {
                    proddisc += (purchaseprod.quantity / activpromoPord.quantity) * activpromoPord.promationPrice + (purchaseprod.quantity % activpromoPord.quantity) * purchaseActProd.price;
                }
            }

            return proddisc;
        }

        public int calculateCombooffers(List<Product> products, List<ActivePromotion> activePromotions, List<PurchaseOrder> purchaseOrders)
        {
            var ComboactivpromoPord = activePromotions.Find(x => x.skuId.Contains('_'));
            if (ComboactivpromoPord != null)
            {
                var prod1 = purchaseOrders.Find(x => x.skuId.Contains(ComboactivpromoPord.skuId.Split('_').First()));
                var prod2 = purchaseOrders.Find(x => x.skuId.Contains(ComboactivpromoPord.skuId.Split('_').Last()));
                if (prod1 != null && prod2 != null)
                {
                    combooffers += ComboactivpromoPord.promationPrice * prod1.quantity;
                    purchaseOrders.Remove(prod1);
                    purchaseOrders.Remove(prod2);
                }                
            }
            return combooffers;
        }

    }
}
