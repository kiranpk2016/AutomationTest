using OpenQA.Selenium.Support.PageObjects;
using SearchAcceptanceTest.Helpers;
using System.Configuration;

namespace SearchAcceptanceTest.Pages
{
    public class Site
    {
        public static string BaseUrl { get; } = ConfigurationManager.AppSettings["BaseUrl"];
        public static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Browser.Driver, page);
            return page;
        }

        public static Home HomePage
        {
            get { return GetPage<Home>(); }
        }

        public static SearchResult SearchResultPage
        {
            get { return GetPage<SearchResult>(); }
        }
    }
}
