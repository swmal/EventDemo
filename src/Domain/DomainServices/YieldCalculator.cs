using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainServices
{
    public class YieldCalculator
    {
        private double GetStockRate(int allotment, int nBookings)
        {
            if (allotment == 0) return 0;
            if (nBookings == 0) return 1;
            return Convert.ToDouble(nBookings)/Convert.ToDouble(allotment);
        }
        public double CaluclateYieldAdjustment(int cost, int price, int noBookings, int allotment)
        {
            if (price < cost) return (double)(cost - price);
            int margin = price - cost;
            var stockRate = GetStockRate(allotment, noBookings);
            if (stockRate < 0.25) return margin * stockRate * -1;
            if (stockRate < 0.5) return margin * stockRate;
            if (stockRate < 0.75) return margin * (stockRate / 2);
            return margin * 0.07;
        }
    }
}
