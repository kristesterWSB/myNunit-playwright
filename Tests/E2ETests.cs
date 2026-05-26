

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
    }
}
