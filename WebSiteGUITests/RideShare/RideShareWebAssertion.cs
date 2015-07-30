using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteGUITests.Assertions;

namespace WebSiteGUITests.RideShare
{
    public class RideShareWebAssertion
    {
        public UIMap UIMap;
        public PageAssertions homePageAsertions;
        public PageAssertions searchRidePageAsertions;
        public PageAssertions publishRidePageAsertions;
        public PageAssertions postRequestPageAsertions;
        public PageAssertions myRidesPageAsertions;

        public RideShareWebAssertion(UIMap UIMap)
        {
            this.UIMap = UIMap;

            initPageAssertions();
        }

        private void initPageAssertions()
        {
            this.homePageAsertions = new PageAssertions(Page.home);
            this.searchRidePageAsertions = new PageAssertions(Page.searchRide);
            this.publishRidePageAsertions = new PageAssertions(Page.publishRide);
            this.postRequestPageAsertions = new PageAssertions(Page.postRequest);
            this.myRidesPageAsertions = new PageAssertions(Page.myRides);
        }

        public void MessageAssertion(string message)
        {
            this.UIMap.AssertPopupMessageExpectedValues.UIWrongemailorpasswordPaneInnerText = message;

            this.UIMap.AssertPopupMessage();
        }

        public void AssertCorrectLogin(string email)
        {
            this.UIMap.AssertUserEmailExpectedValues.UIP1postbguacilPaneInnerText = email;

            this.UIMap.AssertUserEmail();
        }

        public void AssertPage(PageAssertions pageAss)
        {
            this.UIMap.AssertPageExpectedValues.UIHomePaneControlDefinition = pageAss.homePanel;
            this.UIMap.AssertPageExpectedValues.UIAHomeCustomControlDefinition = pageAss.homeLink;

            this.UIMap.AssertPageExpectedValues.UISearchRidePaneControlDefinition = pageAss.searchRidePanel;
            this.UIMap.AssertPageExpectedValues.UIASearchRideCustom1ControlDefinition = pageAss.searchRideLink;

            this.UIMap.AssertPageExpectedValues.UIPostRequestPaneControlDefinition = pageAss.postRequestPanel;
            this.UIMap.AssertPageExpectedValues.UIAPostRequestCustom1ControlDefinition = pageAss.postRequestLink;

            this.UIMap.AssertPageExpectedValues.UIPublishRidePaneControlDefinition = pageAss.punlishRidePanel;
            this.UIMap.AssertPageExpectedValues.UIAPublishRideCustomControlDefinition = pageAss.publishRideLink;

            this.UIMap.AssertPageExpectedValues.UIMyRidesPaneControlDefinition = pageAss.myRidesPanel;
            this.UIMap.AssertPageExpectedValues.UIAMyRidesCustomControlDefinition = pageAss.myRidesLink;

            this.UIMap.AssertPage();
        }

        public void AssertHomePage()
        {
            this.AssertPage(this.homePageAsertions);
        }

        public void AssertSearchRidePage()
        {
            this.AssertPage(this.searchRidePageAsertions);
        }

        public void AssertPostRequestPage()
        {
            this.AssertPage(this.postRequestPageAsertions);
        }

        public void AssertPublishRidePage()
        {
            this.AssertPage(this.publishRidePageAsertions);
        }

        public void AssertMyRidesPage()
        {
            this.AssertPage(this.myRidesPageAsertions);
        }

        public void AssertRegisterPanel()
        {
            this.UIMap.AssertRegisterPanel();
        }

        public void AssertStop(int position, string text)
        {
            switch (position)
            {
                case 1:
                    this.UIMap.AssertFirstStopExpectedValues.UIFirsOutCustomInnerText = text.ToLower();
                    this.UIMap.AssertFirstStop();
                    break;
                case 2:
                    this.UIMap.AssertSecondStopExpectedValues.UISecondOutCustomInnerText = text.ToLower();
                    this.UIMap.AssertSecondStop();
                    break;
                case 3:
                    this.UIMap.AssertThirdStopExpectedValues.UIThirdOutCustomInnerText = text.ToLower();
                    this.UIMap.AssertThirdStop();
                    break;
                case 4:
                    this.UIMap.AssertFourthStopExpectedValues.UIFourthOutCustomInnerText = text.ToLower();;
                    this.UIMap.AssertFourthStop();
                    break;
                case 5:
                    this.UIMap.AssertFifthStopExpectedValues.UIFifthOutCustomInnerText = text.ToLower();;
                    this.UIMap.AssertFifthStop();
                    break;
                default:
                    throw new Exception("Bad Assertion Arguments");
            }
        }
    }
}
