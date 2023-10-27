using System;
using System.IO;
using System.Text;
using OpenQA.Selenium;

namespace XtramileTest.Scripts
{
    public class Util
    {
        private readonly IWebDriver _driver;

        public Util(IWebDriver driver)
        {
            _driver = driver;
        }

        //public void TakeScreenshotWithDate(IWebDriver driver, string Path, string FileName, ScreenshotImageFormat Format)
        //{
        //    int ScreenCounter = 0;
        //    ScreenCounter++; //Updates the number of screenshots that we took during the execution

        //    StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
        //    TimeAndDate.Replace("/", "_");
        //    TimeAndDate.Replace(":", "_");

        //    DirectoryInfo Validation = new DirectoryInfo(Path); //System IO object

        //    if (Validation.Exists == true) //Capture screen if the path is available
        //    {
        //        ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(Path + ScreenCounter.ToString() + "." + FileName + TimeAndDate.ToString() + "." + Format, Format);
        //    }
        //    else //Create the folder and then Capture the screen
        //    {
        //        Validation.Create();
        //        ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(Path + ScreenCounter.ToString() + "." + FileName + TimeAndDate.ToString() + "." + Format, Format);
        //    }
        //}

        public string GetBasePath()
        {
            string path = Directory.GetCurrentDirectory();
            return Path.GetFullPath(Path.Combine(path, "..", "..", ".."));
        }

        public string GetScreenshotPath()
        {
            return Path.GetFullPath(Path.Combine(GetBasePath(), "TestResults", "Exception/"));
        }
    }
}