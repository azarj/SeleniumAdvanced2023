using OpenQA.Selenium;
using SeleniumAdvanced.Framework.Driver;

namespace SeleniumAdvanced.Framework.Pages
{
    public class LoginPage : FactoryPage
    {
        public IWebElement TxtUsername => Driver.FindElement(By.Id("email"));
        public IWebElement TxtPassword => Driver.FindElement(By.Id("password"));
        public IWebElement BtnLogin => Driver.FindElement(By.Id("submit"));

        public DashboardPage Login(string username = "admin@phptravels.com", string password = "demoadmin")
        {
            TxtUsername.PerformSendKeys(username);
            TxtPassword.PerformSendKeys(password);
            return BtnLogin.NavigateToPage<DashboardPage>();
        }
    }
}
