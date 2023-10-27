using OpenQA.Selenium;
using XtramileTest.PageObjects.Database;

namespace XtramileTest.Test
{
    class TestDatabase
    {
        private DatabasePage DatabasePage;
        private readonly IWebDriver _driver;

        public TestDatabase(IWebDriver driver)
        {
            _driver = driver;
            DatabasePage = new DatabasePage(driver);
        }

        //Test Filter computer
        public void FilterComputer()
        {
            DatabasePage.Navigate();
            DatabasePage.FilterComputer("ACE");
        }

        //Test Add a new computer
        public void AddComputer()
        {
            DatabasePage.Navigate();
            DatabasePage.AddComputer("WaskitaPC", "2022-02-02", "2023-03-03", "Sony");
        }

        //Test Edit computer
        public void EditComputer()
        {
            DatabasePage.Navigate();
            DatabasePage.EditComputer("ACE", "Acer Iconia", "Acer Edited", "2022-02-02", "2023-03-03", "Nokia");
        }

        //Test Delete computer
        public void DeleteComputer()
        {
            DatabasePage.Navigate();
            DatabasePage.DeleteComputer("Acer Iconia", "Acer Iconia");
        }

        //Test Pagination
        public void PaginationCheck()
        {
            DatabasePage.Navigate();
            DatabasePage.PaginationCheck();
        }
    }
}
