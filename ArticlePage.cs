using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace myNUnit
{
    public class ArticlePage : BasePage
    {

        private readonly ILocator _articleHeader;

        public ArticlePage(IPage page) : base(page)
        {
            _articleHeader = _page.Locator("h1");
        }

        public async Task ValidateArticleHeaderAsync(string expectedHeader)
        {
            await Expect(_articleHeader).ToHaveTextAsync(expectedHeader);
        }
    }
}
