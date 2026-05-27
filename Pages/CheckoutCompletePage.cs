using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;


namespace myNUnit.Pages
{
    public class CheckoutCompletePage : BasePage
    {
        private readonly ILocator _completeHeaderText;
        public CheckoutCompletePage(IPage page) : base(page)
        {
            _completeHeaderText = _page.Locator("[data-test='complete-header']");
        }

        #region Assertions

        public async Task ValidateCheckoutCompletedOrderAsync(string expectedMessage)
        {
            await Expect(_completeHeaderText).ToBeVisibleAsync();
            await Expect(_completeHeaderText).ToHaveTextAsync(expectedMessage);
        }

        #endregion
    }
}
