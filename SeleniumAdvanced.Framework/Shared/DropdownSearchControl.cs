using OpenQA.Selenium;
using SeleniumAdvanced.Framework.Driver;
using SeleniumAdvanced.Framework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvanced.Framework.Shared
{
    public class DropdownSearchControl: FactoryPage
    {
        public IWebElement TxtSearch => Driver.FindElement(By.CssSelector("input[type=search]"));

        public IList<IWebElement> LstItems => Driver.FindElements(By.CssSelector(".select2-results ul li"));

        public void SearchAndSelect(string text)
        {
            TxtSearch.PerformSendKeys(text);
            LstItems.FirstOrDefault(e => e.Text.Contains(text)).PerformClick();
        }
    }
}
