using System;
using OpenQA.Selenium;
using XtramileTest.Data.Text;
using XtramileTest.Scripts;
using Xunit;

namespace XtramileTest.PageObjects.Alert
{
    class AlertPage
    {
        private WaitHelper _wait;
        private IWebDriver _driver;

        public AlertPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WaitHelper(driver);
        }

        public String AlertURL = "https://the-internet.herokuapp.com/javascript_alerts";
        public IWebElement BtnJSAlert => _driver.FindElement(By.CssSelector("button[onclick='jsAlert()']"));
        public IWebElement BtnJSConfirm => _driver.FindElement(By.CssSelector("button[onclick='jsConfirm()']"));
        public IWebElement BtnJSPrompt => _driver.FindElement(By.CssSelector("button[onclick='jsPrompt()']"));
        public By TxtResultBy = By.Id("result");
        public IWebElement TxtResult => _driver.FindElement(TxtResultBy);
        public IAlert AlertWin => _driver.SwitchTo().Alert();

        public void Navigate()
        {
            _driver.Navigate().GoToUrl(AlertURL);
        }

        public void ClickJSALertOK()
        {
            BtnJSAlert.Click();

            //assert text inside alert
            Assert.Equal(StaticText.AlertText, AlertWin.Text);

            //confirm ok
            AlertWin.Accept();

            _wait.WaitUntilElementExists(TxtResultBy);
            Console.WriteLine(TxtResult.Text);

            //assert text result
            Assert.Equal(StaticText.AlertTextResult, TxtResult.Text);
        }

        public void ClickJSConfirmOK()
        {
            BtnJSConfirm.Click();

            //assert text inside alert
            Assert.Equal(StaticText.AlertConfirm, AlertWin.Text);

            //confirm ok
            AlertWin.Accept();

            _wait.WaitUntilElementExists(TxtResultBy);
            Console.WriteLine(TxtResult.Text);

            //assert text result
            Assert.Equal(StaticText.AlertConfirmOK, TxtResult.Text);
        }

        public void ClickJSConfirmCancel()
        {
            BtnJSConfirm.Click();

            //assert text inside alert
            Assert.Equal(StaticText.AlertConfirm, AlertWin.Text);

            //confirm cancel
            AlertWin.Dismiss();

            _wait.WaitUntilElementExists(TxtResultBy);
            Console.WriteLine(TxtResult.Text);

            //assert text result
            Assert.Equal(StaticText.AlertConfirmCancel, TxtResult.Text);
        }

        public void ClickJSPromptOK(string input)
        {
            BtnJSPrompt.Click();

            //assert text inside alert
            Assert.Equal(StaticText.AlertPrompt, AlertWin.Text);

            //input text
            AlertWin.SendKeys(input);

            //confirm ok
            AlertWin.Accept();

            _wait.WaitUntilElementExists(TxtResultBy);
            Console.WriteLine(TxtResult.Text);

            //assert text result
            Assert.Equal(String.Concat(StaticText.AlertPromptOK, input), TxtResult.Text);
        }

        public void ClickJSPromptCancel(string input)
        {
            BtnJSPrompt.Click();

            //assert text inside alert
            Assert.Equal(StaticText.AlertPrompt, AlertWin.Text);

            //input text
            AlertWin.SendKeys(input);

            //confirm ok
            AlertWin.Dismiss();

            _wait.WaitUntilElementExists(TxtResultBy);
            Console.WriteLine(TxtResult.Text);

            //assert text result
            Assert.Equal(StaticText.AlertPromptCancel, TxtResult.Text);
        }
    }
}
