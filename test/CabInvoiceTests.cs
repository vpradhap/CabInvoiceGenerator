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
            CabInvoice invoiceGenerator = new CabInvoice(RideType.NORMAL);
            double distance = 20;  
            int time = 45; 

            double actualFare = invoiceGenerator.CalculateFare(distance, time);
            double expectedFare = 245;

            Assert.AreEqual(expectedFare, actualFare);
        }

        [TestMethod()]
        public void GivenDistanceAndTime_CalculateFareMethodShould_ReturnMinimumFare()
        {
            CabInvoice invoiceGenerator = new CabInvoice(RideType.NORMAL);
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
            CabInvoice invoiceGenerator = new CabInvoice(RideType.NORMAL);
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            double actual = summary.totalFare;
            Assert.AreEqual(expected, actual);
        }

        //Test case developed for testing the multiple rides implementation
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
            CabInvoice invoiceGenerator = new CabInvoice(RideType.NORMAL);
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(summary, expected);
        }

        [TestMethod()]
        public void GivenUserId_InvoiceServiceShould_ReturnListOfRides()
        {
            Ride[] rides =
            {
                new Ride(1.0, 1),
                new Ride(2.0, 2),
                new Ride(3.0, 2),
                new Ride(4.0, 4),
                new Ride(5.0, 3)
            };
            string userId = "12345";
            CabInvoice invoiceGenerator = new CabInvoice(RideType.NORMAL);
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRide(userId, rides);
            Ride[] actual = rideRepository.GetRides(userId);
            Assert.AreEqual(rides.Length, actual.Length);
        }

        [TestMethod()]
        public void GivenInvalidRideType_Should_Return_CabInvoiceException()
        {
            try
            {
                double distance = -5; 
                int time = 20;   
                CabInvoice invoiceGenerator = new CabInvoice();
                double fare = invoiceGenerator.CalculateFare(distance, time);
            }
            catch (CabInvoiceException ex)
            {
                Assert.AreEqual(ex.type, CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE);
            }
        }

        [TestMethod()]
        public void GivenInvalidDistance_Should_Return_CabInvoiceException()
        {
            try
            {
                double distance = -5; 
                int time = 20;   
                CabInvoice invoiceGenerator = new CabInvoice(RideType.NORMAL);
                double fare = invoiceGenerator.CalculateFare(distance, time);
            }
            catch (CabInvoiceException ex)
            {
                Assert.AreEqual(ex.type, CabInvoiceException.ExceptionType.INVALID_DISTANCE);
            }
        }

        [TestMethod()]
        public void GivenInvalidTime_Should_Return_CabInvoiceException()
        {
            try
            {
                double distance = 5;
                int time = -20;
                CabInvoice invoiceGenerator = new CabInvoice(RideType.NORMAL);
                double fare = invoiceGenerator.CalculateFare(distance, time);
            }
            catch (CabInvoiceException ex)
            {
                Assert.AreEqual(ex.type, CabInvoiceException.ExceptionType.INVALID_TIME);
            }
        }

        [TestMethod()]
        public void GivenInvalidUserId_InvoiceServiceShould_ReturnCabInvoiceException()
        {
            try
            {
                RideRepository rideRepository = new RideRepository();
                Ride[] actual = rideRepository.GetRides("InvalidUserID");
            }
            catch (CabInvoiceException ex)
            {
                Assert.AreEqual(ex.type, CabInvoiceException.ExceptionType.INVALID_USER_ID);
            }
        }

        [TestMethod()]
        public void GivenNullRides_InvoiceServiceShould_ReturnCabInvoiceException()
        {
            try
            {
                Ride[] rides =
                {
                    new Ride(5, 20),
                    null,
                    new Ride(2, 10)
                };
                RideRepository rideRepository = new RideRepository();
                rideRepository.AddRide("111", rides);
            }
            catch (CabInvoiceException ex)
            {
                Assert.AreEqual(ex.type, CabInvoiceException.ExceptionType.NULL_RIDES);
            }
        }
    }
}
