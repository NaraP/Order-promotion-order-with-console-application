using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
   public class Order
    {
        public int OrderID { get; set; }
        public List<Product> Products { get; set; }

        public Order(int _oid, List<Product> _prods)
        {
            this.OrderID = _oid;
            this.Products = _prods;
        }
    }
}
