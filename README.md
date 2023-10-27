## Test for Xtramile Automation Test in C#

This Repository contain test for the following test cases under directory `Data/Document`:

    Ahmad Waskita - Test Cases.xslx

To edit the code you can use [Visual Studio](https://visualstudio.microsoft.com/) using file:

    XtramileTest.sln

Before running the automation test, make sure all project dependencies are installed:

     - DotNetSeleniumExtras.WaitHelpers 
     - Microsoft.NET.Test.Sdk
     - Selenium.Support
     - Selenium.WebDriver
     - Selenium.WebDriver.ChromeDriver
     - xunit
     - xunit.runner.visualstudio
     - coverlet.collector

Also make sure chrome browser version having the same version with `Selenium.WebDriver.ChromeDriver` version.

To run the automation test, you can use command line from parent directory with this command:

    dotnet test --logger "trx;LogFileName=TestResult.trx"

The test result will be shown immediately on the command line.

**To view the test result in html format, you can use Allure report:**
1. make sure allure report is installed ([allure installation](https://docs.qameta.io/allure/#_installing_a_commandline))
2. open directory `TestResults`
3. run the following command on terminal `npx allure serve ./` (it will read .trx file)
