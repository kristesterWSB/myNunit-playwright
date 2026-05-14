using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions; //linijka dająca dostęp do Expect() w POM

namespace myNUnit
{
    public class IntroPage : BasePage
    {
        private readonly ILocator _mainHeader;
        public IntroPage(IPage page) : base(page)
        {
            _mainHeader = _page.Locator("h1");
        }

        public async Task ValidateIntroHeaderAsync()
        {
            await Expect(_mainHeader).ToHaveTextAsync("Installation");
        }
    }
}
