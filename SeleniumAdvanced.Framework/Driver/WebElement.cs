using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvanced.Framework.Driver
{
    public static class WebElement
    {
        public static IWebElement Element(IWebElement element)
        {
            element.WaitForElement();
            return element;
        }

        public static void PerformSendKeys(this IWebElement element, string text)
        {
            Element(element).SendKeys(text);
        }

        public static void PerformClick(this IWebElement element)
        {
            Element(element).Click();
        }

        public static T NavigateToPage<T>(this IWebElement element) where T: class
        {
            PerformClick(element);
            var page = Activator.CreateInstance(typeof(T));
            return (T)page;
        }

        public static void PerformJsClick(this IWebElement element)
        {
            var js = (Browser.BrowserInit.Instance as IJavaScriptExecutor);
            js.ExecuteScript("arguments[0].click()", element);
        }
    }
}
