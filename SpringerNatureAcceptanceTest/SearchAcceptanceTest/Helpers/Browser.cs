using System;
using System.IO;
using OpenQA.Selenium;
using System.Drawing.Imaging;
using OpenQA.Selenium.Chrome;

namespace SearchAcceptanceTest.Helpers
{
    public static class Browser
    {
        public static IWebDriver Driver { get; private set; }

        public static void InitializeBrowser()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        public static void TakeErrorScreenshot(string title)
        {
            var timestamp = DateTime.Now.ToString("dd-MMM-yyyy hh.mm.ss");
            var currentDir = Environment.CurrentDirectory;
            const string folderName = "\\ErrorScreenshots";
            Directory.CreateDirectory(currentDir + folderName);
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            screenshot.SaveAsFile(currentDir + folderName + "\\" + title + " - " + timestamp + ".png", ImageFormat.Png);
        }

        public static void Quit()
        {
            if (Driver == null) return;
            Driver.Quit();
            Driver = null;
        }
    }
}
