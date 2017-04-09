using TechTalk.SpecFlow;

namespace SearchAcceptanceTest.Helpers
{
    [Binding]
    public class StepBase
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            if (Browser.Driver == null)
                Browser.InitializeBrowser();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                if (ScenarioContext.Current.TestError != null)
                {
                    Browser.TakeErrorScreenshot(ScenarioContext.Current.ScenarioInfo.Title);
                }
            }
            finally
            {
                Browser.Quit();
            }
        }
    }
}
