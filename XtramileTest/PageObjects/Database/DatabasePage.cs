using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using XtramileTest.Data.Text;
using XtramileTest.Scripts;
using Xunit;

namespace XtramileTest.PageObjects.Database
{
    class DatabasePage
    {
        private WaitHelper _wait;
        private IWebDriver _driver;

        public DatabasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WaitHelper(driver);
        }

        public string DatabaseURL = "http://computer-database.gatling.io/computers";
        public By LblHeaderBy = By.CssSelector("section#main h1");
        public IWebElement LblHeader => _driver.FindElement(LblHeaderBy);
        public By BannerBy => By.CssSelector("div.alert-message");
        public IWebElement Banner => _driver.FindElement(BannerBy);
        public IWebElement TxtFilter => _driver.FindElement(By.Id("searchbox"));
        public IWebElement BtnFilter => _driver.FindElement(By.Id("searchsubmit"));
        public IWebElement BtnAddComputer => _driver.FindElement(By.Id("add"));

        public List<IWebElement> ComputerNames => _driver.FindElements(By.CssSelector("td a[href*='computers'")).ToList();

        public IWebElement BtnPreviousPage => _driver.FindElement(By.CssSelector("li.prev"));
        public IWebElement LblCurrentPage => _driver.FindElement(By.CssSelector("li.current"));
        public IWebElement BtnNextPage => _driver.FindElement(By.CssSelector("li.next"));

        //computer form
        public IWebElement BtnDelete => _driver.FindElement(By.CssSelector("form.topRight input.btn.danger"));
        public IWebElement TxtComputerName => _driver.FindElement(By.Id("name"));
        public IWebElement TxtIntroduced => _driver.FindElement(By.Id("introduced"));
        public IWebElement TxtDiscontinued => _driver.FindElement(By.Id("discontinued"));
        public IWebElement DrpdownCompany => _driver.FindElement(By.Id("company"));
        public IWebElement BtnSave => _driver.FindElement(By.CssSelector("div.actions input.btn.primary"));
        public IWebElement BtnCancel => _driver.FindElement(By.CssSelector("div.actions a.btn"));

        public void Navigate()
        {
            _driver.Navigate().GoToUrl(StaticText.DatabaseURL);
        }

        public void AddComputer(string name, string introduced, string discontinued, string company)
        {
            BtnAddComputer.Click();

            _wait.WaitUntilNameURL(String.Concat(StaticText.DatabaseURL,"/new"));
            Assert.Equal(StaticText.HeaderAdd, LblHeader.Text);

            TxtComputerName.SendKeys(name);
            TxtIntroduced.SendKeys(introduced);
            TxtDiscontinued.SendKeys(discontinued);

            SelectElement select = new SelectElement(DrpdownCompany);
            select.SelectByText(company);

            BtnSave.Click();

            _wait.WaitUntilElementExists(BannerBy);

            Assert.Equal(String.Concat(StaticText.AddComputerMessage1, name, StaticText.AddComputerMessageCreated), Banner.Text);
        }

        public void EditComputer(string filter, string edit, string name, string introduced, string discontinued, string company)
        {
            List<IWebElement> computerNames = FilterComputer(filter);

            //search computer to edit
            int index = 0;
            foreach (IWebElement computerName in computerNames)
            {
                if(computerName.Text == edit)
                {
                    index = computerNames.IndexOf(computerName);
                }
            }

            //edit the computer
            computerNames[index].Click();

            _wait.WaitUntilNameURL(String.Concat(StaticText.DatabaseURL, "/543"));
            Assert.Equal(StaticText.HeaderEdit, LblHeader.Text);

            TxtComputerName.Clear();
            TxtIntroduced.Clear();
            TxtDiscontinued.Clear();

            TxtComputerName.SendKeys(name);
            TxtIntroduced.SendKeys(introduced);
            TxtDiscontinued.SendKeys(discontinued);


            SelectElement select = new SelectElement(DrpdownCompany);
            select.SelectByText(company);

            BtnSave.Click();

            _wait.WaitUntilElementExists(BannerBy);

            Assert.Equal(String.Concat(StaticText.AddComputerMessage1, name, StaticText.AddComputerMessageUpdated), Banner.Text);
        }

        public void DeleteComputer(string filter, string edit)
        {
            List<IWebElement> computerNames = FilterComputer(filter);

            //search computer to edit
            int index = 0;
            foreach (IWebElement computerName in computerNames)
            {
                if (computerName.Text == edit)
                {
                    index = computerNames.IndexOf(computerName);
                }
            }

            //delete the computer
            computerNames[index].Click();

            _wait.WaitUntilElementExists(LblHeaderBy);
            Assert.Equal(StaticText.HeaderEdit, LblHeader.Text);

            BtnDelete.Click();

            _wait.WaitUntilElementExists(BannerBy);

            Assert.Equal(String.Concat(StaticText.AddComputerMessage1, edit, StaticText.AddComputerMessageDeleted), Banner.Text);
        }

        public void PaginationCheck()
        {
            //check button previous at first page is disabled
            string attrPrevious = BtnPreviousPage.GetAttribute("class");
            bool disabled = attrPrevious.Contains("disabled", StringComparison.OrdinalIgnoreCase) ? true : false;
            Assert.True(disabled);

            //get total page from header
            string header = LblHeader.Text;
            double total = Int32.Parse(header.Substring(0, header.IndexOf(" ")));

            //assert current page
            Assert.Equal(String.Concat(StaticText.Pagination1, "1", StaticText.Pagination2, "10", StaticText.Pagination3, total), LblCurrentPage.Text);

            //check next page and previous button is enabled
            BtnNextPage.FindElement(By.CssSelector("a")).Click();
            //assert current page
            attrPrevious = BtnPreviousPage.GetAttribute("class");
            disabled = attrPrevious.Contains("disabled", StringComparison.OrdinalIgnoreCase) ? true : false;
            Assert.False(disabled);

            Assert.Equal(String.Concat(StaticText.Pagination1, "11", StaticText.Pagination2, "20", StaticText.Pagination3, total), LblCurrentPage.Text);

            //check button previous page is working
            BtnPreviousPage.FindElement(By.CssSelector("a")).Click();
            //assert current page
            Assert.Equal(String.Concat(StaticText.Pagination1, "1", StaticText.Pagination2, "10", StaticText.Pagination3, total), LblCurrentPage.Text);

            //check last page and button Next is disabled
            string lastPage = ((int)Math.Floor(total / 10)).ToString();
            string lastPageURL = String.Concat("https://computer-database.gatling.io/computers?p=", lastPage, "&n=10&s=name&d=asc");

            _driver.Navigate().GoToUrl(lastPageURL);
            string attrNext = BtnNextPage.GetAttribute("class");
            disabled = attrNext.Contains("disabled", StringComparison.OrdinalIgnoreCase) ? true : false;
            Assert.True(disabled);
            Assert.Equal(String.Concat(StaticText.Pagination1, (Int32.Parse(lastPage)*10+1).ToString(), StaticText.Pagination2, total, StaticText.Pagination3, total), LblCurrentPage.Text);
        }

        public List<IWebElement> FilterComputer(string filter)
        {
            TxtFilter.SendKeys(filter);
            BtnFilter.Click();

            string url_path = filter.Replace(' ', '+');
            _wait.WaitUntilNameURL(String.Concat(StaticText.DatabaseURL, "?f=", url_path));
            
            if(ComputerNames.Count() == 1)
            {
                Assert.Equal(StaticText.HeaderFilter, LblHeader.Text);
            } else if(ComputerNames.Count() > 1)
            {
                Assert.Equal(String.Concat(ComputerNames.Count().ToString(), StaticText.HeaderFilters), LblHeader.Text);
            }

            return ComputerNames;
        }
    }
}
