using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SearchAcceptanceTest.Helpers;

namespace SearchAcceptanceTest.Pages
{
    public class Home
    {
        [FindsBy(How = How.Id, Using = "query")]
        public IWebElement SearchTxtbox;

        [FindsBy(How = How.Id, Using = "search")]
        public IWebElement SearchBtn;

        [FindsBy(How = How.CssSelector, Using = "#ui-id-1>li")]
        public IList<IWebElement> AutoSuggestionSearchResult;

        [FindsBy(How = How.CssSelector, Using = "#ui-id-1>li>a>strong")]
        public IList<IWebElement> AutoSuggestionSearch;

        [FindsBy(How = How.CssSelector, Using = "#ui-id-1>li:first-child>a")]
        public IWebElement FirstAutoSugesstionLink;

        public Home NavigateToSpringerNature()
        {
            if (Browser.Driver != null)
                Browser.Driver.Navigate().GoToUrl(Site.BaseUrl);
            return this;
        }

        public List<string> AutoSuggestionList()
        {
            List<string> autoSuggList = new List<string>();
            foreach (var search in AutoSuggestionSearchResult)
            {
                autoSuggList.Add(search.Text);
            }

            return autoSuggList;
        }
    }
}
