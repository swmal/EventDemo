using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public static class Queues
    {
        public const string InitialPricing = "InitialPricingQueue";
        public const string ReservationProducts = "Reservation.Products.Queue";
        public const string ReservationPricing = "Reservation.Pricing.Queue";
        public const string ReservationYield = "Reservation.Yield.Queue";
        public const string ReservationTrading = "Reservation.Trading.Queue";
        public const string TradingPricing = "Trading.Pricing.Queue";
        public const string TradingProducts = "Trading.Products.Queue";
        public const string TradingBooking = "Trading.Booking.Queue";
        public const string EventLogger = "EventLogger.Queue";
        public const string YieldingReplay = "Yielding.Replay.Queue";
    }
}
