using OpenQA.Selenium;
using SeleniumAdvanced.Framework.Driver;
using SeleniumAdvanced.Framework.Shared;

namespace SeleniumAdvanced.Framework.Pages
{
    public class AddHotelPage : BaseWebPage
    {
        public DropdownSearchControl dropdownSearchControl = 
            new DropdownSearchControl();

        public IWebElement BtnStatus => Driver.FindElement(By.CssSelector("[title = ' Enabled '"));

        public IWebElement TxtName => Driver.FindElement(By.CssSelector("[name=aG90ZWxzLm5hbWU-]"));

        public IWebElement IfrDescription => Driver.FindElement(By.CssSelector("#cke_1_contents iframe"));

        public IWebElement TxtDescription => Driver.FindElement(By.CssSelector("body"));

        public IWebElement BtnCurrency => Driver.FindElement(By.CssSelector("[name=aG90ZWxzLmN1cnJlbmN5] ~ span"));

        public IWebElement BtnStars => Driver.FindElement(By.CssSelector("[name=aG90ZWxzLnN0YXJz] ~ span"));
        public IWebElement BtnSave => Driver.FindElement(By.CssSelector("[data-task='save']"));
 

        public HotelManagementPage AddHotel(string status, string name, string currency, string stars, string description)
        {
            BtnStatus.PerformClick();
            dropdownSearchControl.SearchAndSelect(status);
            TxtName.PerformSendKeys(name);
            BtnCurrency.PerformClick();
            dropdownSearchControl.SearchAndSelect(currency);
            BtnStars.PerformClick();
            dropdownSearchControl.SearchAndSelect(stars);
            AddDescription(description);

            BtnSave.PerformJsClick();
            return new HotelManagementPage();
        }

        public void AddDescription(string description)
        {
            WaitUtils.WaitForCondition(300, 2000, () => IfrDescription.Enabled);
            Driver.SwitchTo().Frame(IfrDescription);
            TxtDescription.PerformSendKeys(description);
            Driver.SwitchTo().DefaultContent();
        }
    }
}
