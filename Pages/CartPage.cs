using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace myNUnit.Pages
{
    public class CartPage : BasePage
    {
        private readonly ILocator _cartItems;
        private readonly ILocator _checkoutButton;
        public CartPage(IPage page) : base(page)
        {
            _cartItems = _page.Locator("[data-test='inventory-item']");
            _checkoutButton = _page.Locator("[data-test='checkout']");
        }

        public async Task<CheckoutInfoPage> ClickCheckoutButton()
        {
            await _checkoutButton.ClickAsync();
            return new CheckoutInfoPage(_page);
        }

        #region Assertions

        public async Task ValidteCartItem(string itemNameText)
        {
            await Expect(_cartItems).ToHaveCountAsync(1);
            await Expect(_cartItems.First).ToContainTextAsync(itemNameText);
        }

        #endregion
    }
}
