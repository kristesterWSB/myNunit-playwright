using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace myNUnit.Pages
{
    public class InventoryPage : BasePage
    {
        private readonly ILocator _appLogo;
        private readonly ILocator _cartLink;
        public InventoryPage(IPage page) : base(page)
        {
            _appLogo = _page.Locator(".app_logo");
            _cartLink = _page.Locator("[data-test='shopping-cart-link']");
        }

        #region Methods

        public async Task<InventoryPage> ClickAddToCartBikeLightAsync(string productName)
        {
            var productContainer = _page.Locator(".inventory_item").Filter(new() { HasText = productName });
            await productContainer.GetByRole(AriaRole.Button, new() { NameString = $"Add to cart" }).ClickAsync();
            return this;
        }

        public async Task<CartPage> GoToCartAsync()
        {
            await _cartLink.ClickAsync();
            return new CartPage(_page);
        }

        #endregion

        #region Assertions

        public async Task ValidateLoginSucessfullyAsync()
        {
            await Expect(_appLogo).ToBeVisibleAsync();
            await Expect(_appLogo).ToHaveTextAsync("Swag Labs");
        }
        #endregion
    }
}
