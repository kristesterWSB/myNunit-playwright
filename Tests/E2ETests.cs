using myNUnit.TestData;
using Bogus;

namespace myNUnit.Tests 
{
    public class E2ETests : TestBase
    {
        [Test]
        public async Task ShouldItemAddedToBasket()
        {
            var inventoryPage = await LoginViaCookieAsync();
            await inventoryPage.ValidateLoginSucessfullyAsync();
            await inventoryPage.ClickAddToCartBikeLightAsync(Constants.Products.BikeLight);
            var cartPage = await inventoryPage.GoToCartAsync();
            await cartPage.ValidteCartItem(Constants.Products.BikeLight);
        }

        [Test]
        public async Task ShouldCompleteOrderProcess()
        {
            var faker = new Faker("pl");
            var firstName = faker.Name.FirstName();
            var lastName = faker.Name.LastName();
            var postalCode = faker.Address.ZipCode();

            var inventoryPage = await LoginViaCookieAsync();
            await inventoryPage.ClickAddToCartBikeLightAsync(Constants.Products.BikeLight);

            var cartPage = await inventoryPage.GoToCartAsync();
            await cartPage.ValidteCartItem(Constants.Products.BikeLight);

            var checkoutInfoPage = await cartPage.ClickCheckoutButton();
            await checkoutInfoPage.FillCheckoutFormAsync(firstName, lastName, postalCode);

            var checkoutOverviewPage = await checkoutInfoPage.ClickContinueButtonAsync();

            var checkoutCompletePage = await checkoutOverviewPage.ClickFinishButtonAsync();
            await checkoutCompletePage.ValidateCheckoutCompletedOrderAsync(Constants.Messages.OrderSuccess);

        }
    }
}