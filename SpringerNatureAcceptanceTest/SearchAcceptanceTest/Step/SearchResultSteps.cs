using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using SearchAcceptanceTest.Pages;
using SearchAcceptanceTest.Helpers;
using System.Threading;
using Shouldly;

namespace SearchAcceptanceTest.Step
{
    [Binding]
    class SearchResultSteps
    {
        [Given(@"I am on springer nature page")]
        public void GivenIAmOnSpringerNaturePage()
        {
            Site.HomePage.NavigateToSpringerNature();
        }

        [When(@"I enter '(.*)' to search for")]
        public void WhenIEnterToSearchFor(string searchTxt)
        {
            Site.HomePage.SearchTxtbox.SendKeys(searchTxt);
        }

        [When(@"I search for '(.*)'")]
        public void WhenISearchFor(string searchTxt)
        {
            Site.HomePage.SearchTxtbox.SendKeys(searchTxt);
            Site.HomePage.SearchBtn.Click();
        }

        [Then(@"it gives me auto suggestion containing '(.*)'")]
        public void ThenItGivesMeAutoSuggestionContaining(string autoSuggTxt)
        {
            Site.HomePage.AutoSuggestionSearchResult.All(s => s.Text.ToLower().Contains(autoSuggTxt)).ShouldBe(true);
        }

        [Then(@"the entered search text is highlighted")]
        public void ThenTheEnteredSearchTextIsHighlighted()
        {
            Site.HomePage.AutoSuggestionSearch.All(s => s.TagName.Equals("strong")).ShouldBe(true);
        }

        [Then(@"it should give me error message")]
        public void ThenItShouldGiveMeErrorMessage()
        {
            Site.SearchResultPage.SearchHeading.Text.ShouldContain("0 Result(s) for 'Springernaturepage'");
            Site.SearchResultPage.SorryErrorMsg.Text.ShouldContain("Sorry – we couldn’t find what you are looking for. Why not...");
        }

        [Then(@"it should give me search results containing '(.*)'")]
        public void ThenItShouldGiveMeSearchResultsContaining(string searchResult)
        {
            Site.SearchResultPage.SearchResults.All(s => s.Text.ToLower().Contains(searchResult)).ShouldBe(true);
        }

        [When(@"I click on new search link")]
        public void WhenIClickOnNewSearchLink()
        {
            Site.SearchResultPage.NoSearchLink.Click();
        }

        [Then(@"previously entered search text gets cleared")]
        public void ThenPreviouslyEnteredSearchTextGetsCleared()
        {
            Site.HomePage.SearchTxtbox.GetAttribute("value").ShouldBeNullOrEmpty();
            Browser.Driver.Url.ShouldBe($"{Site.BaseUrl}/search");
            Browser.Driver.Url.ShouldNotBe($"{Site.BaseUrl}/search?query=medical");
        }

        [When(@"I click first auto suggested link")]
        public void WhenIClickFirstAutoSuggestedLink()
        {
            Site.HomePage.FirstAutoSugesstionLink.Click();
        }

        [Then(@"it should navigate to search result page of containing auto suggested link")]
        public void ThenItShouldNavigateToSearchResultPageOfContainingAutoSuggestedLink()
        {
            Browser.Driver.Url.ShouldBe($"{Site.BaseUrl}/search?query=Biomedical+Engineering");
            Site.SearchResultPage.SearchHeading.Text.ShouldContain("Result(s) for 'Biomedical Engineering'");
        }

        [When(@"I know the auto suggested search result for '(.*)'")]
        public void WhenIKnowTheAutoSuggestedSearchResultFor(string suggTxt)
        {
            ScenarioContext.Current["First AutoList"] = Site.HomePage.AutoSuggestionList();
        }

        [When(@"I update auto suggestion as '(.*)'")]
        public void WhenIUpdateAutoSuggestionAs(string updateTxt)
        {
            Site.HomePage.SearchTxtbox.Clear();
            Site.HomePage.SearchTxtbox.SendKeys(updateTxt);
            Thread.Sleep(1000);
        }

        [Then(@"it should update the auto suggestion containing '(.*)'")]
        public void ThenItShouldUpdateTheAutoSuggestionContaining(string updateSearch)
        {
            var initialAutoList = (List<string>)ScenarioContext.Current["First AutoList"];
            var currentAutoList = Site.HomePage.AutoSuggestionList();
            initialAutoList.All(s => s.ToLower().Contains(updateSearch)).ShouldBe(false);
            currentAutoList.All(s => s.ToLower().Contains(updateSearch)).ShouldBe(true);
        }
    }
}
