using myNUnit.Extensions;


namespace myNUnit.Tests
{
    public class E2EAdvancedFluentTests : TestBase
    {
        [Test]
        public async Task ShouldCompleteOrderProcessAdvancedFluent()
        {
            await LoginViaCookieAsync()
                .Then(inventory => inventory.ClickAddToCartBikeLightAsync("Sauce Labs Bike Light"))
                .Then(inventory => inventory.GoToCartAsync())
                .Then(cart => cart.ValidteCartItem("Sauce Labs Bike Light"))
                .Then(cart => cart.ClickCheckoutButton())
                .Then(checkoutInfo => checkoutInfo.FillCheckoutFormAsync("John", "Doe", "12345"))
                .Then(checkoutInfo => checkoutInfo.ClickContinueButtonAsync())
                .Then(checkoutOverview => checkoutOverview.ClickFinishButtonAsync())
                .Then(checkoutComplete => checkoutComplete.ValidateCheckoutCompletedOrderAsync("Thank you for your order!"));

        }
    }
}
