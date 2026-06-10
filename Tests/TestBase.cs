using Microsoft.Playwright.NUnit;
using myNUnit.Configuration;
using myNUnit.Pages;
using NUnit.Allure.Core;

namespace myNUnit.Tests
{
    [AllureNUnit]
    public class TestBase : PageTest
    {
        protected LoginPage LoginPage;

        [SetUp]
        public async Task BaseSetup()
        {
            await Context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            await Page.GotoAsync(Config.BaseUrl);
            LoginPage = new LoginPage(Page);
        }

        [TearDown]
        public async Task BaseTearDown()
        {
            bool hasFailed = TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed;
            
            if (hasFailed)
            {
                string testName = TestContext.CurrentContext.Test.Name;
                string tracePath = $"traces/trace-{testName}.zip";
                await Context.Tracing.StopAsync(new() { Path = tracePath });
                Console.WriteLine($"Trace saved to: {tracePath}");
            }
            else
            {
                await Context.Tracing.StopAsync();
            }
        }

        protected async Task<InventoryPage> LoginViaCookieAsync()
        {
            var authHelper = new Helpers.AuthorizationHelper(Page, Context);
            return await authHelper.LoginViaCookieAsync();
        }
    }
}
