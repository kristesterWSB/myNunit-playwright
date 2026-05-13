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
        await HomePage.ClickGetStartedButtonAsync();

        await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
    }
}
