using OpenQA.Selenium;
using XtramileTest.PageObjects.Alert;

namespace XtramileTest.Test
{
    class TestAlert
    {
        private AlertPage AlertPage;

        private readonly IWebDriver _driver;

        public TestAlert(IWebDriver driver)
        {
            _driver = driver;

            AlertPage = new AlertPage(_driver);
        }

        //Test JSAlert
        public void TestJSAlert()
        {
            //navigate to the app
            AlertPage.Navigate();

            //test JSAlert OK
            AlertPage.ClickJSALertOK();
        }

        public void TestJSConfirm()
        {
            //navigate to the app
            AlertPage.Navigate();

            // test JSConfirm OK
            AlertPage.ClickJSConfirmOK();

            //test JSCOnfirm Cancel
            AlertPage.ClickJSConfirmCancel();
        }

        public void TestJSPrompt()
        {
            //navigate to the app
            AlertPage.Navigate();

            //test JSPrompt OK
            AlertPage.ClickJSPromptCancel("Ahmad Waskita");

            //test JSPrompt Cancel
            AlertPage.ClickJSPromptCancel("Ahmad Waskita");
        }
    }
}
