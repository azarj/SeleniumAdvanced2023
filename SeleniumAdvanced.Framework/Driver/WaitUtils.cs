using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvanced.Framework.Driver
{
    public static class WaitUtils
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        public static bool TryWaitForCondition(int n, int t, Func<bool> condition)
        {
            int num = 0;
            while (!condition() && num < n)
            {
                Thread.Sleep(t);
                num++;
            }
            return num < n;
        }

        public static void WaitForCondition(int n, int t, Func<bool> condition, string message = null)
        {
            if (!TryWaitForCondition(n, t, condition))
            {
                throw new Exception(message ?? "Timeout while trying to complete the condition");
            }
        }

        public static bool Available(IWebElement element) => element != null && element.Displayed && element.Enabled;

        public static void WaitForElement(this IWebElement element)
        {
            var wait = new DefaultWait<IWebDriver>(Browser.BrowserInit.Instance)
            {
                Timeout = TimeSpan.FromSeconds(30),
                PollingInterval = TimeSpan.FromMilliseconds(30)
            };
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(TimeoutException));
            wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));
            wait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));

            wait.Until(driver =>
            {
                try
                {
                    log.Info("Starting to evaluate the condition");
                    WaitForCondition(TimeSpan.FromSeconds(30).Seconds, TimeSpan.FromMilliseconds(30).Milliseconds, () => Available(element));
                    return true;
                }
                catch (Exception e)
                {
                    log.Error($"Failed to evaluate the condition due to the following error: {e}");
                }
                return false;
            }
            );
        }

    }
}
