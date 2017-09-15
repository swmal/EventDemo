using Domain;
using KeyValueStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Views
{
    class InventoryItem : ViewBase
    {
        public string ProductId { get; set; }

        public string Name { get; set; }
        public int Allotment { get; set; }
        public int Price { get; set; }

        public TradingActionType TradingState { get; set; }
    }
}
