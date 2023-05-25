using SeleniumAdvanced.Framework.Browser;
using SeleniumAdvanced.Framework.Pages;

namespace SeleniumAdvanced.Tests
{
    public class TestBase : IDisposable
    {
        public LoginPage? LoginPage { get; set; }

        //contstructor instead of TestInitialize
        public TestBase()
        {
            Browser.StartBrowser(BrowserType.Chrome);
            Browser.Instance.Navigate().GoToUrl("https://www.phptravels.net/api/admin");

            LoginPage = new LoginPage();
        }

        //Dispose() instead of TestCleanup
        public void Dispose()
        {
            Browser.Instance.Quit();
        }
    }
}
