using Microsoft.Playwright;

namespace myNUnit.DevTest
{
    public abstract class BasePageDev
    {
        protected readonly IPage _page;
    
            public BasePageDev(IPage page)
            {
                _page = page;
            }
    }
}
