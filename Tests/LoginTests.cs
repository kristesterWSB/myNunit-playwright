using myNUnit.Configuration;
using myNUnit.Pages;

namespace myNUnit.Tests
{
    public class LoginTests : TestBase
    {
        [Test]
        public async Task ShouldLoginSuccessfullyAsStandardUserAsync()
        {
            var inventoryPage = await LoginPage.LoginAsAsync(Config.StandardUser, Config.Password);
            await inventoryPage.ValidateLoginSucessfullyAsync();
        }

        [Test]
        public async Task ShouldBypassLoginUsingCookies()
        {
            var sessionCookie = new Microsoft.Playwright.Cookie
            {
                Name = "session-username",
                Value = Config.StandardUser,
                Url = Config.BaseUrl
            };

            await Context.AddCookiesAsync(new[] { sessionCookie });
            await Page.GotoAsync(Config.BaseUrl + "/inventory.html");
            var inventoryPage = new InventoryPage(Page);
            await inventoryPage.ValidateLoginSucessfullyAsync();
        }


    }
}
