using Microsoft.Playwright;

namespace myNUnit
{
    public class SearchModal : BasePage
    {
        private readonly ILocator _searchInput;
        private readonly ILocator _searchResult;
        public SearchModal(IPage page)  : base(page)
        {
            _searchInput = _page.GetByPlaceholder("Search docs");
            _searchResult = _page.Locator(".DocSearch-Hit a");
        }

        public async Task TypeTextAsync(string text)
        {
            await _searchInput.FillAsync(text);
        }

        public async Task ClearInputFieldAsync()
        {
            await _searchInput.ClearAsync();
        }

        public async Task<ArticlePage> ClickFirstItemAsync()
        {
            await _searchResult.First.ClickAsync();
            return new ArticlePage(_page);
        }
    }
}
