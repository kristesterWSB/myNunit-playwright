using myNUnit.Extensions;


namespace myNUnit.Tests
{
    public class E2EAdvancedFluentTests : TestBase
    {
        [Test]
        [TestCase("Sauce Labs Bike Light", "John", "Doe", "12345", "Thank you for your order!")]
        public async Task ShouldCompleteOrderProcessAdvancedFluent(string itemName, string firstName, string lastName, string postalCode, string expectedMessage)
        {
            await LoginViaCookieAsync()
                .Then(inventory => inventory.ClickAddToCartBikeLightAsync(itemName))
                .Then(inventory => inventory.GoToCartAsync())
                .Then(cart => cart.ValidteCartItem(itemName))
                .Then(cart => cart.ClickCheckoutButton())
                .Then(checkoutInfo => checkoutInfo.FillCheckoutFormAsync(firstName, lastName, postalCode))
                .Then(checkoutInfo => checkoutInfo.ClickContinueButtonAsync())
                .Then(checkoutOverview => checkoutOverview.ClickFinishButtonAsync())
                .Then(checkoutComplete => checkoutComplete.ValidateCheckoutCompletedOrderAsync(expectedMessage));

        }
    }
}
