using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Messaging;
using Domain;

namespace Events
{
    [TestClass]
    public class Precook
    {
        [TestMethod]
        public void ClearAllQueues()
        {
            var client = new Client();
            client.ClearQueue(Queues.InitialPricing);
            client.ClearQueue(Queues.TradingProducts);
            client.ClearQueue(Queues.TradingPricing);
            client.ClearQueue(Queues.TradingBooking);
            client.ClearQueue(Queues.ReservationPricing);
            client.ClearQueue(Queues.ReservationProducts);
            client.ClearQueue(Queues.ReservationYield);
            client.ClearQueue(Queues.EventLogger);
        }

        [TestMethod]
        public void SetupReservation()
        {
            var client = new Client();

            // Product
            var product1 = DomainObjectFactory.Create<Product>();
            product1.Name = "Apollon";
            product1.State = ProductState.Sales;
            client.ExchangeType = ExchangeType.Topic;
            client.Publish(Exchanges.Products, "Sales", product1.ToBytes());

            var product2 = DomainObjectFactory.Create<Product>();
            product2.Name = "Nausicaa";
            product2.State = ProductState.Sales;
            client.ExchangeType = ExchangeType.Topic;
            client.Publish(Exchanges.Products, "Sales", product2.ToBytes());

            // Price
            var price = DomainObjectFactory.Create<ProductPrice>();
            price.ProductId = product1.Id;
            price.Cost = 350;
            price.Price = 450;
            client.ExchangeType = ExchangeType.Fanout;
            client.Publish(Exchanges.ProductPrice, price.ToBytes());

            price = DomainObjectFactory.Create<ProductPrice>();
            price.ProductId = product2.Id;
            price.Cost = 375;
            price.Price = 475;
            client.Publish(Exchanges.ProductPrice, price.ToBytes());

            // cleanup
            client.ClearQueue(Queues.InitialPricing);
            client.ClearQueue(Queues.TradingProducts);
            client.ClearQueue(Queues.TradingPricing);
            client.ClearQueue(Queues.EventLogger);

        }

        [TestMethod]
        public void SetupReservationProductfyFirst()
        {
            var client = new Client();

            client.ExchangeType = ExchangeType.Topic;

            // Product
            var product1 = DomainObjectFactory.Create<Product>();
            product1.Name = "Apollon";
            product1.State = ProductState.Sales;
            client.Publish(Exchanges.Products, "Sales", product1.ToBytes());

            var product2 = DomainObjectFactory.Create<Product>();
            product2.Name = "Nausicaa";
            product2.State = ProductState.Productify;
            client.Publish(Exchanges.Products, "Productify", product2.ToBytes());

            client.ExchangeType = ExchangeType.Fanout;

            // Price
            var price = DomainObjectFactory.Create<ProductPrice>();
            price.ProductId = product1.Id;
            price.Cost = 350;
            price.Price = 450;
            client.Publish(Exchanges.ProductPrice, price.ToBytes());

            price = DomainObjectFactory.Create<ProductPrice>();
            price.ProductId = product2.Id;
            price.Cost = 375;
            price.Price = 475;
            client.Publish(Exchanges.ProductPrice, price.ToBytes());

            client.ExchangeType = ExchangeType.Topic;

            product2.State = ProductState.Sales;
            client.Publish(Exchanges.Products, "Sales", product2.ToBytes());

            // cleanup
            client.ClearQueue(Queues.InitialPricing);
            client.ClearQueue(Queues.TradingProducts);
            client.ClearQueue(Queues.TradingPricing);
            client.ClearQueue(Queues.EventLogger);

        }

        [TestMethod]
        public void SendBookingToTrading()
        {
            var client = new Client();

            client.ExchangeType = ExchangeType.Topic;
            // Product
            var product = DomainObjectFactory.Create<Product>();
            product.Name = "Apollon";
            product.State = ProductState.Sales;
            client.Publish(Exchanges.Products, "Sales", product.ToBytes());

            // Booking
            var booking = DomainObjectFactory.Create<Booking>();
            booking.ProductId = "P1";
            booking.Price = 345;
            client.Publish(Exchanges.Bookings, booking.ToBytes());
        }
    }
}
