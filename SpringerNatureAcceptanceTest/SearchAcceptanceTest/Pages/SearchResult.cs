using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace SearchAcceptanceTest.Pages
{
    public class SearchResult
    {
        [FindsBy(How = How.ClassName, Using = "header")]
        public IWebElement SearchHeading;

        [FindsBy(How = How.CssSelector, Using = "#no-results-message>h2")]
        public IWebElement SorryErrorMsg;

        [FindsBy(How = How.Id, Using = "global-search-new")]
        public IWebElement NoSearchLink;

        [FindsBy(How = How.ClassName, Using = "title")]
        public IList<IWebElement> SearchResults;
    }
}
