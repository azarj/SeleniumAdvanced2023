using SeleniumAdvanced.Framework.Pages;

namespace SeleniumAdvanced.Tests
{
    public class HotelTests : TestBase
    {
        [Fact]
        public void AddAndDeleteHotel()
        {
            var dashboardPage = LoginPage.Login();
            var hmp = dashboardPage.menuItemControl.NavigateTo<HotelManagementPage>("Hotels","Hotels");
            var addHotel = hmp.ClickAddButton<AddHotelPage>();
            hmp = addHotel.AddHotel("Disabled", "George hotel name", "USD", "7", "description");
            hmp.DeleteHotel("George hotel name");
        }

        [Fact]
        public void AddAndDeleteFlight()
        {
            var airlineName = "2 Sqn No 1 Elementary Flying Training School";

            var dashboardPage = LoginPage.Login();
            var flightMngPage = dashboardPage.menuItemControl.NavigateTo<FlightsManagementPage>("Flights", "Flights");
            var addFlight = flightMngPage.ClickAddButton<AddFlightPage>();
            flightMngPage = addFlight.AddFlight(airlineName);

            //assert grid line exists
            flightMngPage.DeleteHotel(airlineName);
        }
    }
}