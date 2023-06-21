using OpenQA.Selenium;
using SeleniumAdvanced.Framework.Browser;
using System.ComponentModel;

namespace SeleniumAdvanced.Framework.Pages
{
    public class LoginPage
    {
        public IWebDriver Driver { get; set; }

        public LoginPage()
        {
            if(Driver == null)
            {
                Driver = BrowserInit.Instance;
            }
        }

        public IWebElement TxtUsername => Driver.FindElement(By.Id("email"));
        public IWebElement TxtPassword => Driver.FindElement(By.Id("password"));
        public IWebElement BtnLogin => Driver.FindElement(By.Id("submit"));

        public DashboardPage Login(string username = "admin@phptravels.com", string password = "demoadmin")
        {
            TxtUsername.SendKeys(username);
            TxtPassword.SendKeys(password);

            BtnLogin.Click();
            return new DashboardPage();
        }
    }
}
