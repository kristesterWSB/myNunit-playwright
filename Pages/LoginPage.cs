using Microsoft.Playwright;

namespace myNUnit.Pages
{
    public class LoginPage : BasePage
    {
        private readonly ILocator _usernameInput;
        private readonly ILocator _passwordInput;
        private readonly ILocator _loginButton;
        private readonly ILocator _errorMessage;

        public LoginPage(IPage page) : base(page)
        {
            _usernameInput = _page.Locator("[data-test='username']");
            _passwordInput = _page.Locator("[data-test='password']");
            _loginButton = _page.Locator("[data-test='login-button']");
            _errorMessage = _page.Locator("[data-test='error']");
        }

        public async Task<InventoryPage> LoginAsAsync(string username, string password)
        {
            await _usernameInput.FillAsync(username);
            await _passwordInput.FillAsync(password);
            await _loginButton.ClickAsync();

            return new InventoryPage(_page);
        }

    }
}
