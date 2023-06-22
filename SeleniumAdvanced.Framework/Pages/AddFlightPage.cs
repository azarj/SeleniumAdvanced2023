using OpenQA.Selenium;
using SeleniumAdvanced.Framework.Driver;
using SeleniumAdvanced.Framework.Shared;

namespace SeleniumAdvanced.Framework.Pages
{
    public class AddFlightPage : BaseWebPage
    {

        public DropdownSearchControl dropdownSearchControl =
            new DropdownSearchControl();

        public IWebElement BtnAirline => Driver.FindElement(By.CssSelector("[name='ZmxpZ2h0cy5haXJsaW5l'] ~ span"));

        public IWebElement BtnSave => Driver.FindElement(By.CssSelector("[data-task='save']"));

        public FlightsManagementPage AddFlight(string airline)
        {
            BtnAirline.PerformClick();
            dropdownSearchControl.SearchAndSelect(airline);
            
            BtnSave.PerformClick();
            return new FlightsManagementPage();
        }
    }
}
