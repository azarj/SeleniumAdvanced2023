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
            //BrowserInit.StartBrowser(BrowserType.RemoteWebdriver, "http://nwmaasui-app01.centric-dev.lan:4444");
            BrowserInit.StartBrowser(BrowserType.Chrome);
            BrowserInit.Instance.Navigate().GoToUrl("https://phptravels.net/admin/login.php");

            LoginPage = new LoginPage();
        }

        //Dispose() instead of TestCleanup
        public void Dispose()
        {
            BrowserInit.Instance.Quit();
        }
    }
}
