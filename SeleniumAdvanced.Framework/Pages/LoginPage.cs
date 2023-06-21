using OpenQA.Selenium;
using SeleniumAdvanced.Framework.Browser;
using SeleniumAdvanced.Framework.Driver;
using System.ComponentModel;

namespace SeleniumAdvanced.Framework.Pages
{
    public class LoginPage : FactoryPage
    {
        public IWebElement TxtUsername => Driver.FindElement(By.Id("email"));
        public IWebElement TxtPassword => Driver.FindElement(By.Id("password"));
        public IWebElement BtnLogin => Driver.FindElement(By.Id("submit"));

        public DashboardPage Login(string username = "admin@phptravels.com", string password = "demoadmin")
        {
            //TxtUsername.SendKeys(username);
            //TxtPassword.SendKeys(password);

            //BtnLogin.Click();
            //return new DashboardPage();
            TxtUsername.PerformSendKeys(username);
            TxtPassword.PerformSendKeys(password);
            return BtnLogin.NavigateToPage<DashboardPage>();
        }
    }
}
