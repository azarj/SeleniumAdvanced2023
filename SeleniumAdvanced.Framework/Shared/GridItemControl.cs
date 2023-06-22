using OpenQA.Selenium;
using SeleniumAdvanced.Framework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvanced.Framework.Shared
{
    public class GridItemControl: FactoryPage
    {
        public IList<IWebElement> LstItems => Driver.FindElements(By.CssSelector("tbody tr"));

        public IWebElement LblItem(string text)
        {
            var isStale = true;
            while (isStale)
            {
                try
                {
                    var item = LstItems.FirstOrDefault(e => e.Text.Contains(text));
                    isStale = false;
                    return item;
                }
                catch (Exception)
                {
                    //log error
                }
            }
            return null;
        }

        public IWebElement BtnDelete(string text) =>
            LblItem(text).FindElement(By.CssSelector("[title=Remove]"));
    }
}
