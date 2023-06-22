using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumAdvanced.Framework.Browser
{
    public class BrowserInit
    {
        public static IWebDriver Instance { get; set; }

        public static void StartBrowser(BrowserType browserTypes = BrowserType.Chrome, string remoteUrl = null)
        {
            switch (browserTypes)
            {
                case BrowserType.Chrome:
                    var chromeOptions = BuildChromeOptions();
                    Instance = new ChromeDriver(chromeOptions);
                    break;

                case BrowserType.RemoteWebdriver:
                    Instance = new OpenQA.Selenium.Remote.RemoteWebDriver(new Uri(remoteUrl), new ChromeOptions());
                    break;
            }
        }

        private static ChromeOptions BuildChromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");

            return chromeOptions;
        }

        public static void SaveScreenshot(string className, string testMethodName)
        {
            var fileName = "";
            try
            {
                var screenshotPath = "C:\\work\\";
                var now = DateTime.Now;
                var date = now.ToString("yyyMMdd");
                fileName = $"{className}_{testMethodName}_{date}_{now.Hour}_{now.Minute}_{now.Second}_{now.Millisecond}";
                var fileFullPath = screenshotPath + fileName + ".png";
                //Log.Info("Start taking screenshot...");
                var attemptNo = 0;
                var success = false;

                do
                {
                    success = TakeScreenShot(fileFullPath);
                    attemptNo++;
                    //Log.Info($"Saving file: {fileName} attempt {attemptNo}");
                } while (!success && attemptNo < 5);
            }
            catch (Exception)
            {
                //Log.Error($"Cannot save screenshot for: {fileName},/n because of error: {ex.Message}");
            }
        }

        private static bool TakeScreenShot(string fileName)
        {
            try
            {
                var screenShot = ((ITakesScreenshot)Instance).GetScreenshot();
                screenShot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
                return true;
            }
            catch (Exception e)
            {
                //Log.Error($"Error when saving screenshot '{fileName}'", e);
            }

            return false;
        }
    }
}
