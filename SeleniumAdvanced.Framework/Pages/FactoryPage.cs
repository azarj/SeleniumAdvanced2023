using OpenQA.Selenium;
using SeleniumAdvanced.Framework.Browser;

namespace SeleniumAdvanced.Framework.Pages
{
    public class FactoryPage
    {
        public IWebDriver Driver { get; set; }

        public FactoryPage()
        {
            if (Driver == null)
            {
                Driver = BrowserInit.Instance;
            }
        }

    }
}
