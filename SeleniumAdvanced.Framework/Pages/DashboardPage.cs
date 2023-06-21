using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using SeleniumAdvanced.Framework.Browser;
using System.Collections.ObjectModel;

namespace SeleniumAdvanced.Framework.Pages
{
    public class DashboardPage
    {
        public IWebDriver Driver { get; set; }

        public DashboardPage() 
        { 
            if (Driver == null)
            {
                Driver = BrowserInit.Instance;
            }
        }

        public IList<IWebElement> MenuList => Driver.FindElements(By.CssSelector("li.mb-0"));
        public IList<IWebElement> SubmenuList => Driver.FindElements(By.CssSelector("div.collapse.show ul > li"));

        public T NavigateTo<T>(string menuItem, string submenuItem) where T : class, new()
        {
            MenuList.FirstOrDefault(el => el.Text.Equals(menuItem)).Click();
            SubmenuList.FirstOrDefault(el => el.Text.Equals(submenuItem)).Click();

            return new T();
        }
    }
}
