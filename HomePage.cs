using Microsoft.Playwright;

namespace myNUnit
{
    public class HomePage : BasePage
    {
        private readonly ILocator _getStartedButton;
        private readonly ILocator _searchButton;


        public HomePage(IPage page) : base(page)
        {
            _getStartedButton = _page.GetByRole(AriaRole.Link, new() { NameString = "Get started" });
            _searchButton = _page.GetByRole(AriaRole.Button, new() { NameString = "Search" });
        }

        // Metoda, która będzie klikać w przycisk "Get started".
        public async Task<IntroPage> ClickGetStartedButtonAsync()
        {
            await _getStartedButton.ClickAsync();

            return new IntroPage(_page);
        }

        public async Task<SearchModal> ClickSearchButtonAsync()
        {
            await _searchButton.ClickAsync();
            return new SearchModal(_page);
        }
    }
}
