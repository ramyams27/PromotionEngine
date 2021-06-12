using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> baseProducts = new List<Product>();
            List<ActivePromotion> activePromotions = new List<ActivePromotion>();
            List<PurchaseOrder> purchaseOrders = new List<PurchaseOrder>();
            Calculation calculate = new Calculation();
            setupMasterData(baseProducts);
            setupActivePromotionData(activePromotions);
            Inputs(purchaseOrders);            
            int total = calculate. calculatePrdodDis(baseProducts,activePromotions,purchaseOrders);
            Console.WriteLine("The Total is = " + total);
            Console.ReadLine();
        }

        private static void Inputs(List<PurchaseOrder> purchaseOrders)
        {
            Console.WriteLine("Press -1 to exit");
            
            string input = "1";
            while (input!="-1")
            {
                PurchaseOrder order = new PurchaseOrder();
                Console.WriteLine("EnterSku");
                input = Console.ReadLine();

                if (input == "-1")
                    break;

                order.skuId = input;

                Console.WriteLine("Enter qunatity");
                input = Console.ReadLine();

                if (input == "-1")
                    break;

                order.quantity = Convert.ToInt32(input);

                purchaseOrders.Add(order);

            }
           
        }

        private static void setupActivePromotionData(List<ActivePromotion> activePromotions)
        {
            ActivePromotion p1 = new ActivePromotion("A", 130, 3);
            ActivePromotion p2 = new ActivePromotion("B", 45,2);
            ActivePromotion p3 = new ActivePromotion("C_D", 30, 1);
            activePromotions.Add(p1);
            activePromotions.Add(p2);
            activePromotions.Add(p3);
        }

        static void setupMasterData(List<Product> products)
        {            
            Product p1 = new Product("A",50);
            Product p2 = new Product("B",30);
            Product p3 = new Product("C",20);
            Product p4 = new Product("D",15);
            products.Add(p1);
            products.Add(p2);
            products.Add(p3);
            products.Add(p4);
        }
    }
}
