using OpenQA.Selenium;
using SeleniumAdvanced.Framework.Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
