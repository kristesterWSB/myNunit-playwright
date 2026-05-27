using Microsoft.Playwright;

namespace myNUnit.Pages
{
    public class CheckoutInfoPage : BasePage
    {
        private readonly ILocator _firstNameInputField;
        private readonly ILocator _lastNameInputField;
        private readonly ILocator _zipCodeInputField;
        private readonly ILocator _continueButton;

        public CheckoutInfoPage(IPage page) : base(page)
        {
            _firstNameInputField = _page.Locator("[data-test='firstName']");
            _lastNameInputField = _page.Locator("[data-test='lastName']");
            _zipCodeInputField = _page.Locator("[data-test='postalCode']");
            _continueButton = _page.Locator("[data-test='continue']");
        }

        public async Task<CheckoutInfoPage> FillCheckoutFormAsync(string firstName, string lastName, string zipCode)
        {
            await _firstNameInputField.FillAsync(firstName);
            await _lastNameInputField.FillAsync(lastName);
            await _zipCodeInputField.FillAsync(zipCode);
            return this;
        }

        public async Task<CheckoutOverviewPage> ClickContinueButtonAsync()
        {
            await _continueButton.ClickAsync();
            return new CheckoutOverviewPage(_page);
        }


    }
}
