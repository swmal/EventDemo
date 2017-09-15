using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var productStartInfo = new ProcessStartInfo(@"C:\Development\Labs\EventDemo\ProductLifecycleManager\bin\Debug\ProductLifecycleManager.exe");
            var p1 = Process.Start(productStartInfo);

            var initialPricingStartInfo = new ProcessStartInfo(@"C:\Development\Labs\EventDemo\InitialPricing\bin\Debug\InitialPricing.exe");
            var p2 = Process.Start(initialPricingStartInfo);

            var reservationStartInfo = new ProcessStartInfo(@"C:\Development\Labs\EventDemo\Reservation\bin\Debug\Reservation.exe");
            var p3 = Process.Start(reservationStartInfo);

            var tradingStartInfo = new ProcessStartInfo(@"C:\Development\Labs\EventDemo\Trading\bin\Debug\Trading.exe");
            var p4 = Process.Start(tradingStartInfo);

            var eventLoggerStartInfo = new ProcessStartInfo(@"C:\Development\Labs\EventDemo\EventLogger\bin\Debug\EventLogger.exe");
            var p5 = Process.Start(eventLoggerStartInfo);

            Console.ReadKey();

            try
            {
                p1.Kill();
                p2.Kill();
                p3.Kill();
                p4.Kill();
                p5.Kill();
            }
            catch(Exception e)
            {

            }
        }
    }
}
