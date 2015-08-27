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

        #region missing fields

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

        #endregion

        #region invalid input

        [TestMethod]
        public void PublishRide_NoStops_InvalidInput_DateWithChar()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate("a", month.ToString(), year.ToString());
            ride.fromTime = "14:00";
            ride.toTime = "15:00";
            ride.price = "100";
            ride.maxPassengers = "4";
            ride.smoking = Smoking.yes;

            adapter.PublishRide(ride);

            assert.MessageAssertion(this.data.BadDate);
        }

        [TestMethod]
        public void PublishRide_NoStops_InvalidInput_DateWithNegative()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate("-1", month.ToString(), year.ToString());
            ride.fromTime = "14:00";
            ride.toTime = "15:00";
            ride.price = "100";
            ride.maxPassengers = "4";
            ride.smoking = Smoking.yes;

            adapter.PublishRide(ride);

            assert.MessageAssertion(this.data.BadDate);
        }

        [TestMethod]
        public void PublishRide_NoStops_InvalidInput_TimeWithChar()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate(day, month, year);
            ride.fromTime = "1a:00";
            ride.toTime = "15:00";
            ride.price = "100";
            ride.maxPassengers = "4";
            ride.smoking = Smoking.yes;

            adapter.PublishRide(ride);

            assert.MessageAssertion(this.data.BadTimeInterval);
        }

        [TestMethod]
        public void PublishRide_NoStops_InvalidInput_TimeWithNegative()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate(day, month, year);
            ride.fromTime = "-14:00";
            ride.toTime = "15:00";
            ride.price = "100";
            ride.maxPassengers = "4";
            ride.smoking = Smoking.yes;

            adapter.PublishRide(ride);

            assert.MessageAssertion(this.data.BadTimeInterval);
        }

        [TestMethod]
        public void PublishRide_NoStops_InvalidInput_PassengerWithChar()
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
            ride.maxPassengers = "4a";
            ride.smoking = Smoking.yes;

            adapter.PublishRide(ride);

            assert.MessageAssertion(this.data.BadPassengersAmount);
        }

        [TestMethod]
        public void PublishRide_NoStops_InvalidInput_PassengerWithNegative()
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
            ride.maxPassengers = "-4";
            ride.smoking = Smoking.yes;

            adapter.PublishRide(ride);

            assert.MessageAssertion(this.data.BadPassengersAmount);
        }

        [TestMethod]
        public void PublishRide_NoStops_InvalidInput_PriceWithChar()
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
            ride.price = "10a0";
            ride.maxPassengers = "4";
            ride.smoking = Smoking.yes;

            adapter.PublishRide(ride);

            assert.MessageAssertion(this.data.BadPrice);
        }

        [TestMethod]
        public void PublishRide_NoStops_InvalidInput_PriceWithNegative()
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
            ride.price = "-100";
            ride.maxPassengers = "4";
            ride.smoking = Smoking.yes;

            adapter.PublishRide(ride);

            assert.MessageAssertion(this.data.BadPrice);
        }

        #endregion

        #region bad data

        [TestMethod]
        public void PublishRidePastDate()
        {
            DateTime now = DateTime.Now.AddYears(-1);
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

            assert.MessageAssertion(this.data.BadDate);
        }

        [TestMethod]
        public void PublishRideBadTimeInterval()
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
            ride.toTime = "13:00";
            ride.price = "100";
            ride.maxPassengers = "4";

            adapter.PublishRide(ride);

            assert.MessageAssertion(this.data.BadTimeInterval);
        }

        #endregion
        
        #region correct input

        [TestMethod]
        public void PublishRideAllCorrectNoStopsSmoking()
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
            ride.smoking = Smoking.yes;
            adapter.PublishRide(ride);

            assert.AssertMyRidesPage();
        }

        [TestMethod]
        public void PublishRideAllCorrectNoStopsNotSmoking()
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
            ride.smoking = Smoking.no;
            adapter.PublishRide(ride);

            assert.AssertMyRidesPage();
        }

        [TestMethod]
        public void PublishRideAllCorrectDontCareStopsSmoking()
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
            ride.smoking = Smoking.dontCare;
            adapter.PublishRide(ride);

            assert.AssertMyRidesPage();
        }

        #endregion 

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

        #region empty fields
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

        #endregion

        #region invalid input

        [TestMethod]
        public void PublishRide_WithStops_InvalidInput_DateWithChar()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate("a", month.ToString(), year.ToString());
            ride.fromTime = "14:00";
            ride.toTime = "15:00";
            ride.price = "100";
            ride.maxPassengers = "4";
            ride.smoking = Smoking.yes;
            addStops();

            adapter.PublishRide(ride);

            assert.MessageAssertion(this.data.BadDate);
        }

        [TestMethod]
        public void PublishRide_WithStops_InvalidInput_DateWithNegative()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate("-1", month.ToString(), year.ToString());
            ride.fromTime = "14:00";
            ride.toTime = "15:00";
            ride.price = "100";
            ride.maxPassengers = "4";
            ride.smoking = Smoking.yes;
            addStops();

            adapter.PublishRide(ride);

            assert.MessageAssertion(this.data.BadDate);
        }

        [TestMethod]
        public void PublishRide_WithStops_InvalidInput_TimeWithChar()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate(day, month, year);
            ride.fromTime = "1a:00";
            ride.toTime = "15:00";
            ride.price = "100";
            ride.maxPassengers = "4";
            ride.smoking = Smoking.yes;
            addStops();

            adapter.PublishRide(ride);

            assert.MessageAssertion(this.data.BadTimeInterval);
        }

        [TestMethod]
        public void PublishRide_WithStops_InvalidInput_TimeWithNegative()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate(day, month, year);
            ride.fromTime = "-14:00";
            ride.toTime = "15:00";
            ride.price = "100";
            ride.maxPassengers = "4";
            ride.smoking = Smoking.yes;
            addStops();

            adapter.PublishRide(ride);

            assert.MessageAssertion(this.data.BadTimeInterval);
        }

        [TestMethod]
        public void PublishRide_WithStops_InvalidInput_PassengerWithChar()
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
            ride.maxPassengers = "4a";
            ride.smoking = Smoking.yes;
            addStops();

            adapter.PublishRide(ride);

            assert.MessageAssertion(this.data.BadPassengersAmount);
        }

        [TestMethod]
        public void PublishRide_WithStops_InvalidInput_PassengerWithNegative()
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
            ride.maxPassengers = "-4";
            ride.smoking = Smoking.yes;
            addStops();

            adapter.PublishRide(ride);

            assert.MessageAssertion(this.data.BadPassengersAmount);
        }

        [TestMethod]
        public void PublishRide_WithStops_InvalidInput_PriceWithChar()
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
            ride.price = "10a0";
            ride.maxPassengers = "4";
            ride.smoking = Smoking.yes;
            addStops();

            adapter.PublishRide(ride);

            assert.MessageAssertion(this.data.BadPrice);
        }

        [TestMethod]
        public void PublishRide_WithStops_InvalidInput_PriceWithNegative()
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
            ride.price = "-100";
            ride.maxPassengers = "4";
            ride.smoking = Smoking.yes;
            addStops();

            adapter.PublishRide(ride);

            assert.MessageAssertion(this.data.BadPrice);
        }

        #endregion

        #region bad data

        [TestMethod]
        public void PublishRide_WithStops_PastDate()
        {
            DateTime now = DateTime.Now.AddYears(-1);
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

            assert.MessageAssertion(this.data.BadDate);
        }

        [TestMethod]
        public void PublishRide_WithStops_BadTimeInterval()
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
            ride.toTime = "13:00";
            ride.price = "100";
            ride.maxPassengers = "4";

            adapter.PublishRide(ride);

            assert.MessageAssertion(this.data.BadTimeInterval);
        }

        #endregion

        #region correct input

        [TestMethod]
        public void PublishRide_WithStops_AllCorrectSmoking()
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
            ride.smoking = Smoking.yes;
            addStops();

            adapter.PublishRide(ride);

            assert.AssertMyRidesPage();
        }

        [TestMethod]
        public void PublishRide_WithStops_AllCorrectNotSmoking()
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
            ride.smoking = Smoking.no;
            addStops();

            adapter.PublishRide(ride);

            assert.AssertMyRidesPage();
        }

        [TestMethod]
        public void PublishRide_WithStops_AllCorrectDontCareSmoking()
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
            ride.smoking = Smoking.dontCare;
            addStops();

            adapter.PublishRide(ride);

            assert.AssertMyRidesPage();
        }
        #endregion

        #endregion

        private void addStops()
        {
            adapter.AddStop("haifa");
            adapter.AddStop("ako");
        }

        protected override void TestInitialize()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            adapter.Login(data.CorrectEmail, data.CorrectPassword);
            adapter.GoToPublishRide();
        }
    }
}
