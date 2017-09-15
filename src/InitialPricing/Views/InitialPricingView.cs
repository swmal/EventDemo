using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialPricing.Views
{
    public class InitialPricingView
    {
        public string ProductId { get; set; }

        public string Name { get; set; }
        public ProductState State { get; set; }
        public int Price { get; set; }
    }
}
