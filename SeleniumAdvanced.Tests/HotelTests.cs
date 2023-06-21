using SeleniumAdvanced.Framework.Pages;

namespace SeleniumAdvanced.Tests
{
    public class HotelTests : TestBase
    {
        [Fact]
        public void AddAndDeleteHotel()
        {
            var dashboardPage = LoginPage.Login();

            //dashboard page navigate to hotels
            var hmp = dashboardPage.NavigateTo<HotelManagementPage>("Hotels","Hotels");
        }

    }
}