using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainServices
{
    public class CostCalculator
    {
        public int Calculate(int price)
        {
            return Convert.ToInt32(price * 0.8);
        }
    }
}
