using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace XtramileTest.Scripts
{
    public class WaitHelper
    {
        private readonly IWebDriver driver;

        public WaitHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitUntilNameURL(string url)
        {
            WebDriverWait waitClickable = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            waitClickable.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(url));
        }

        public void WaitUntilElementExists(By el)
        {
            WebDriverWait waitClickable = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            waitClickable.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(el));
        }

    }
}