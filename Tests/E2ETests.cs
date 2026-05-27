namespace myNUnit.Tests
{
    public class E2ETests : TestBase
    {
        [Test]
        public async Task ShouldItemAddedToBasket()
        {
            var inventoryPage = await LoginViaCookieAsync();
            await inventoryPage.ValidateLoginSucessfullyAsync();
            await inventoryPage.ClickAddToCartBikeLightAsync("Sauce Labs Bike Light");
            var cartPage = await inventoryPage.GoToCartAsync();
            await cartPage.ValidteCartItem("Sauce Labs Bike Light");
        }

        [Test]
        public async Task ShouldCompleteOrderProcess()
        {
            var inventoryPage = await LoginViaCookieAsync();
            await inventoryPage.ClickAddToCartBikeLightAsync("Sauce Labs Bike Light");

            var cartPage = await inventoryPage.GoToCartAsync();
            await cartPage.ValidteCartItem("Sauce Labs Bike Light");

            var checkoutInfoPage = await cartPage.ClickCheckoutButton();
            await checkoutInfoPage.FillCheckoutFormAsync("John", "Doe", "12345");

            var checkoutOverviewPage = await checkoutInfoPage.ClickContinueButtonAsync();

            var checkoutCompletePage = await checkoutOverviewPage.ClickFinishButtonAsync();
            await checkoutCompletePage.ValidateCheckoutCompletedOrderAsync("Thank you for your order!");

        }
    }
}