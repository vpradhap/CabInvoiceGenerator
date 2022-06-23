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
    }
}