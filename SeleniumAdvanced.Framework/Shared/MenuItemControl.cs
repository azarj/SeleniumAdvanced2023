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
    public class MenuItemControl: FactoryPage
    {
        public IList<IWebElement> MenuList => Driver.FindElements(By.CssSelector("li.mb-0"));
        public IList<IWebElement> SubmenuList => Driver.FindElements(By.CssSelector("div.collapse.show ul > li"));

        public T NavigateTo<T>(string menuItem, string submenuItem) where T : class, new()
        {
            MenuList.FirstOrDefault(el => el.Text.Equals(menuItem)).PerformClick();
            WaitUtils.WaitForCondition(30, 10, () => SubmenuList.Count > 0);
            SubmenuList.FirstOrDefault(el => el.Text.Equals(submenuItem)).PerformClick();

            return new T();
        }
    }
}
