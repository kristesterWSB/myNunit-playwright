using Microsoft.Playwright;

namespace myNUnit.Pages
{
    public class CheckoutOverviewPage : BasePage
    {
        private readonly ILocator _finishButton;
        public CheckoutOverviewPage(IPage page) : base(page)
        {
            _finishButton = _page.Locator("[data-test='finish']");
        }
        
        public async Task<CheckoutCompletePage> ClickFinishButtonAsync()
        {
            await _finishButton.ClickAsync();
            return new CheckoutCompletePage(_page);
        }


    }
}
