using System.Text.RegularExpressions;

namespace myNUnit;

public class NavigationTests : TestBase
{
    [Test]
    public async Task ShouldNavigateToIntroPage()
    {
        // Brak GotoAsync! (Zrobił to za nas [SetUp])
        // Brak var homePage = new HomePage()! (Zrobił to za nas [SetUp])
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

        // po prostu używamy gotowego obiektu HomePage, który odziedziczyliśmy po TestBase
        // FLUENT POM: Klikamy przycisk, a metoda sama "oddaje" nam obiekt IntroPage
        var introPage = await HomePage.ClickGetStartedButtonAsync();
        
        await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));

        await introPage.ValidateIntroHeaderAsync();
    }

    [Test]
    public async Task ShouldSearchForLocatorsArticle()
    {
        var searchModal = await HomePage.ClickSearchButtonAsync();

        await searchModal.TypeTextAsync("bad text");
        await searchModal.ClearInputFieldAsync();

        await searchModal.TypeTextAsync("locators");

        var articlePage = await searchModal.ClickFirstItemAsync();

        await articlePage.ValidateArticleHeaderAsync("Locators");
    }
}
