using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using WebSiteGUITests.RideShare.Data;


namespace WebSiteGUITests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class PublishRideTests : RideShareWebSiteTests
    {
        private PublishRide ride;

        public PublishRideTests()
        {
            this.ride = new PublishRide();
        }

        #region Tests - No Stops

        [TestMethod]
        public void PublishRideEmptyFields()
        {
            ride.Clear();

            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadSource);
        }

        [TestMethod]
        public void PublishRideEmptyFields_AllBut_Source()
        {
            ride.Clear();
            ride.source = "telaviv";
            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadDestination);
        }

        [TestMethod]
        public void PublishRideEmptyFields_AllBut_Source_Destination()
        {
            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadDate);
        }

        [TestMethod]
        public void PublishRideEmptyFields_AllBut_Source_Destination_Date()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate(day, month, year);
            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadTimeInterval);
        }

        [TestMethod]
        public void PublishRideEmptyFields_AllBut_Source_Destination_Date_FromTime()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate(day, month, year);
            ride.fromTime = "14:00";
            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadTimeInterval);
        }

        [TestMethod]
        public void PublishRideEmptyFields_AllBut_Source_Destination_Date_FromTime_ToTime()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate(day, month, year);
            ride.fromTime = "14:00";
            ride.toTime = "15:00";
            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadPrice);
        }

        [TestMethod]
        public void PublishRideEmptyFields_AllBut_Source_Destination_Date_FromTime_ToTime_Price()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate(day, month, year);
            ride.fromTime = "14:00";
            ride.toTime = "15:00";
            ride.price = "100";
            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadPassengersAmount);
        }

        [TestMethod]
        public void PublishRideAllCorrectNoStops()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate(day, month, year);
            ride.fromTime = "14:00";
            ride.toTime = "15:00";
            ride.price = "100";
            ride.maxPassengers = "4";
            adapter.PublishRide(ride);

            assert.AssertMyRidesPage();
        }

        #endregion

        #region Tests - Only Stops
        [TestMethod]
        public void PublishRideAddStops()
        {
            adapter.AddStop("haifa");
            adapter.AddStop("telaviv");
            adapter.AddStop("beersheva");

            string stopHaifa = adapter.GetStop(1);
            string stopTlv = adapter.GetStop(2);
            string stopBsh = adapter.GetStop(3);

            assert.AssertStop(1, stopHaifa);
            assert.AssertStop(2, stopTlv);
            assert.AssertStop(3, stopBsh);
        }

        [TestMethod]
        public void PublishRideDeleteStops()
        {
            adapter.AddStop("haifa");
            adapter.AddStop("telaviv");
            adapter.AddStop("beersheva");

            string stopHaifa = adapter.GetStop(1);
            string stopTlv = adapter.GetStop(2);
            string stopBsh = adapter.GetStop(3);

            adapter.DeleteStop(2);
            assert.AssertStop(1, stopHaifa);
            assert.AssertStop(2, stopBsh);

            adapter.DeleteStop(1);
            assert.AssertStop(1, stopBsh);
        }

        [TestMethod]
        public void PublishRideAddAndDeleteStops()
        {
            adapter.AddStop("haifa");
            adapter.AddStop("telaviv");
            adapter.AddStop("beersheva");

            string stopHaifa = adapter.GetStop(1);
            string stopTlv = adapter.GetStop(2);
            string stopBsh = adapter.GetStop(3);

            adapter.DeleteStop(2);
            adapter.DeleteStop(1);

            adapter.AddStop("kiryat shmona");
            string stopKShmona = adapter.GetStop(2);

            adapter.DeleteStop(1);
            assert.AssertStop(1, stopKShmona);

            adapter.DeleteStop(1);

            adapter.AddStop("kiryat yam");
            string stopKYam = adapter.GetStop(1);
            assert.AssertStop(1, stopKYam);

            adapter.AddStop("Haifa");
            assert.AssertStop(2, stopHaifa);
        }

        #endregion

        #region Tests - With Stops

        private void addStops()
        {
            adapter.AddStop("haifa");
            adapter.AddStop("ako");
        }

        [TestMethod]
        public void PublishRide_WithStops_EmptyFields()
        {
            ride.Clear();

            addStops();

            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadSource);
        }

        [TestMethod]
        public void PublishRide_WithStops_EmptyFields_AllBut_Source()
        {
            ride.Clear();
            ride.source = "telaviv";

            addStops();

            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadDestination);
        }

        [TestMethod]
        public void PublishRide_WithStops_EmptyFields_AllBut_Source_Destination()
        {
            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            
            addStops();

            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadDate);
        }

        [TestMethod]
        public void PublishRide_WithStops_EmptyFields_AllBut_Source_Destination_Date()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate(day, month, year);

            addStops();

            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadTimeInterval);
        }

        [TestMethod]
        public void PublishRide_WithStops_EmptyFields_AllBut_Source_Destination_Date_FromTime()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate(day, month, year);
            ride.fromTime = "14:00";

            addStops();

            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadTimeInterval);
        }

        [TestMethod]
        public void PublishRide_WithStops_EmptyFields_AllBut_Source_Destination_Date_FromTime_ToTime()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate(day, month, year);
            ride.fromTime = "14:00";
            ride.toTime = "15:00";

            addStops();

            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadPrice);
        }

        [TestMethod]
        public void PublishRide_WithStops_EmptyFields_AllBut_Source_Destination_Date_FromTime_ToTime_Price()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate(day, month, year);
            ride.fromTime = "14:00";
            ride.toTime = "15:00";
            ride.price = "100";

            addStops();

            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadPassengersAmount);
        }

        [TestMethod]
        public void PublishRide_WithStops_AllCorrect()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate(day, month, year);
            ride.fromTime = "14:00";
            ride.toTime = "15:00";
            ride.price = "100";
            ride.maxPassengers = "4";

            addStops();

            adapter.PublishRide(ride);

            assert.AssertMyRidesPage();
        }

        #endregion

        protected override void TestInitialize()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            adapter.Login(data.CorrectEmail, data.CorrectPassword);
            adapter.GoToPublishRide();
        }
    }
}
