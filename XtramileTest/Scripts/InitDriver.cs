using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using Xunit.Abstractions;

namespace XtramileTest.Scripts
{
    public class InitDriver : IDisposable
    {
        protected IWebDriver driver;
        protected ITestOutputHelper testOutputHelper;

        public InitDriver(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
            try
            {
                ChromeOptions options = new ChromeOptions();

                //start headless
                //options.AddArguments("--headless");

                //start in UI mode
                options.AddArguments("start-maximized");

                //default chrome binary using .net package selenium
                string chromeBinary;
                chromeBinary = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                var firingDriver = new EventFiringWebDriver(new ChromeDriver(chromeBinary, options, TimeSpan.FromSeconds(120)));
                //firingDriver.ExceptionThrown += FiringDriver_TakeScreenshotOnException;

                driver = firingDriver;

                //Set default 'wait' period to 60 seconds for getting elements
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            } catch (Exception e)
            {
                Console.WriteLine($"Exception when starting Chrome! {e}", e);
                throw;
            }
        }

        //private void FiringDriver_TakeScreenshotOnException(object sender, WebDriverExceptionEventArgs e)
        //{
        //    Util util = new Util(driver);
        //    util.TakeScreenshotWithDate(driver, util.GetScreenshotPath(), "", ScreenshotImageFormat.Png);
        //}

        private void ScreenRecording()
        {
            
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
