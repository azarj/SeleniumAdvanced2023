using OpenQA.Selenium;
using SeleniumAdvanced.Framework.Driver;
using SeleniumAdvanced.Framework.Shared;

namespace SeleniumAdvanced.Framework.Pages
{
    public class BaseManagementPage : BaseWebPage
    {
        public GridItemControl gridItemControl = new GridItemControl();

        public IWebElement BtnAddd => Driver.FindElement(By.CssSelector("[class=icon-plus]"));

        public T ClickAddButton<T>() where T : class, new()
        {
            BtnAddd.PerformClick();
            return new T();
        }

        public void DeleteHotel(string name)
        {
            gridItemControl.BtnDelete(name).PerformClick();
            Driver.SwitchTo().Alert().Accept();
        }
    }
}
