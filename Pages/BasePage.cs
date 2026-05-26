using Microsoft.Playwright;

namespace myNUnit.Pages
{
    public abstract class BasePage
    {
        protected readonly IPage _page;
    
            public BasePage(IPage page)
            {
                _page = page;
        }
    }
}
