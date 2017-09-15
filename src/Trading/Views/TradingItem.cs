using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading.Views
{
    public class TradingItem
    {
        public string ProductId { get; set; }

        public string Name { get; set; }

        public ProductState State { get; set; }

        public int NoBookings { get; set; }

        public int Cost { get; set; }

        public int InitialPrice { get; set; }

        public int Price { get; set; }

        public int Allotment { get; set; }

        public int YieldAdjustment { get; set; }

        public TradingActionType LastAction{ get; set; }
    }
}
