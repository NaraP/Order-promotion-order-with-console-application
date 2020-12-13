using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // create list of promotions
          //we need to add information about Product's count
          Dictionary<String, int> d1 = new Dictionary<String, int>();
            d1.Add("A", 3);
            Dictionary<String, int> d2 = new Dictionary<String, int>();
            d2.Add("B", 2);
            Dictionary<String, int> d3 = new Dictionary<String, int>();
            d3.Add("C", 1);
            d3.Add("D", 1);

            List<Promotion> promotions = new List<Promotion>()
                            {
                                   new Promotion(1, d1, 130),
                                   new Promotion(2, d2, 45),
                                   new Promotion(3, d3, 30)
                             };

            //create orders
            List<Order> orders = new List<Order>();
            Order order1 = new Order(1, new List<Product>() { new Product("A"), new Product("A"), new Product("B"), new Product("B"), new Product("C"), new Product("D") });
            Order order2 = new Order(2, new List<Product>() { new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("B") });
            Order order3 = new Order(3, new List<Product>() { new Product("A"), new Product("A"), new Product("D"), new Product("B"), new Product("B") });
            orders.AddRange(new Order[] { order1, order2, order3 });

            var A = order1.Products[0].Price;
            var B = order1.Products[2].Price;
            var C = order1.Products[4].Price;
            var D = order3.Products[2].Price;

            Console.WriteLine();

            Console.WriteLine("Unit price for SKU IDs");
            Console.WriteLine($"A:\t{A}");
            Console.WriteLine($"B:\t{B}");
            Console.WriteLine($"C:\t{C}");
            Console.WriteLine($"D:\t{D}");
            Console.WriteLine();

            Console.WriteLine("SCENARIO A");
            Console.WriteLine();
            Console.WriteLine($"1 * A:\t{A}");
            Console.WriteLine($"1 * B :\t{B}");
            Console.WriteLine($"1 * C :\t{C}");
            Console.WriteLine(("").PadRight(24, '-'));
            Console.WriteLine($"Total:\t{A + B + C}");
            Console.WriteLine();

            Console.WriteLine("SCENARIO B");
            Console.WriteLine();
            Console.WriteLine($"5 * A:\t{"130 + 2 * A"}");
            Console.WriteLine($" 5 * B :\t{"45 + 45 + B"}");
            Console.WriteLine($"1 * C :\t{"20"}");
            Console.WriteLine(("").PadRight(24, '-'));
            Console.WriteLine($"Total:\t{130 + 2 * A + 45 + 45 + B + C}");
            Console.WriteLine();

            Console.WriteLine("SCENARIO C");
            Console.WriteLine();
            Console.WriteLine($"3 * A:\t{"130"}");
            Console.WriteLine($"5 * B :\t{"45 + 45 + 1 * 30"}");
            Console.WriteLine($"1 * C :\t{'-'}");
            Console.WriteLine($"1 * D :\t{"30"}");
            Console.WriteLine(("").PadRight(24, '-'));
            Console.WriteLine($"Total:\t{130 + 45 + 45 + 1 * B + 30}");
            Console.WriteLine();

            Console.WriteLine("Check if order meets promotion");

            Console.WriteLine();

            //check if order meets promotion
            foreach (Order ord in orders)
            {
                List<decimal> promoprices = promotions
                    .Select(promo => PromotionChecker.GetTotalPrice(ord, promo))
                    .ToList();
                decimal origprice = ord.Products.Sum(x => x.Price);
                decimal promoprice = promoprices.Sum();
                Console.WriteLine($"OrderID: {ord.OrderID} => Original price: {origprice.ToString("0.00")} | Rebate: {promoprice.ToString("0.00")} | Final price: {(origprice - promoprice).ToString("0.00")}");
            }
            Console.ReadLine();
        }
    }
}

