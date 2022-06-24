using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cab_Invoice_Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab_Invoice_Generator.test
{
    [TestClass()]
    public class InvoiceGeneratorTests
    {
        [TestMethod()]
        public void GivenDistanceAndTime_CalculateFareMethodShould_ReturnTotalFare()
        {
            CabInvoice invoiceGenerator = new CabInvoice();
            double distance = 20;
            int time = 45;

            double actualFare = invoiceGenerator.CalculateFare(distance, time);
            double expectedFare = 245;

            Assert.AreEqual(expectedFare, actualFare);
        }

        [TestMethod()]
        public void GivenDistanceAndTime_CalculateFareMethodShould_ReturnMinimumFare()
        {
            CabInvoice invoiceGenerator = new CabInvoice();
            double distance = 0.2;
            int time = 2;

            double actualFare = invoiceGenerator.CalculateFare(distance, time);
            double expectedFare = 5;

            Assert.AreEqual(expectedFare, actualFare);
        }
        [TestMethod()]
        public void Given5Rides_CalculateFareMethodShould_ReturnTotalFare()
        {
            Ride[] rides =
            {
                new Ride(1.0, 1),
                new Ride(2.0, 2),
                new Ride(3.0, 2),
                new Ride(4.0, 4),
                new Ride(5.0, 3),
                new Ride(6.0, 3)
            };
            double expected = 225;
            CabInvoice invoiceGenerator = new CabInvoice();
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            double actual = summary.totalFare;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Given5Rides_InvoiceSummaryShould_ReturnEnhancedInvoiceSummary()
        {
            Ride[] rides =
            {
                new Ride(1.0, 1),
                new Ride(2.0, 2),
                new Ride(3.0, 2),
                new Ride(4.0, 4),
                new Ride(5.0, 3),
                new Ride(6.0, 3)
            };
            InvoiceSummary expected = new InvoiceSummary(6, 225);
            CabInvoice invoiceGenerator = new CabInvoice();
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(summary, expected);
        }
    }
}
