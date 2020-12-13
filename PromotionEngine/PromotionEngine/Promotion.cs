using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
  public  class Promotion
    {
        public int PromotionID { get; set; }
        public Dictionary<string, int> ProductInfo { get; set; }
        public decimal PromoPrice { get; set; }

        public Promotion(int _promID, Dictionary<string, int> _prodInfo, decimal _pp)
        {
            this.PromotionID = _promID;
            this.ProductInfo = _prodInfo;
            this.PromoPrice = _pp;
        }
    }
}
