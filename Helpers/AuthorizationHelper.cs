using Microsoft.Playwright;
using myNUnit.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myNUnit.Helpers
{
    public class AuthorizationHelper
    {
        private readonly IPage _page;
        private readonly IBrowserContext _context;
        public AuthorizationHelper(IPage page, IBrowserContext context)
        {
            _page = page;
            _context = context;
        }

        public async Task<InventoryPage> LoginViaCookieAsync()
        {
            var sessionCookie = new Microsoft.Playwright.Cookie
            {
                Name = "session-username",
                Value = Configuration.Config.StandardUser,
                Url = Configuration.Config.BaseUrl,
            };

            await _context.AddCookiesAsync(new[] { sessionCookie });
            await _page.GotoAsync(Configuration.Config.BaseUrl + "inventory.html");

            var inventoryPage = new InventoryPage(_page);
            await inventoryPage.ValidateLoginSucessfullyAsync();

            return inventoryPage;
        }
    }
}
