using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myNUnit
{
    public class HomePage
    {
        // Zmienna przechowująca referencję do karty przeglądarki
        private readonly IPage _page;
        // Lokator zdefiniowany tylko RAZ w całym projekcie!
        private readonly ILocator _getStartedButton;

        // Konstruktor. Uruchamia się w momencie, gdy w teście powiemy "new HomePage()".
        // "Połyka" on naszą przeglądarkę z testu i ustawia lokatory.
        public HomePage(IPage page)
        {
            _page = page;
            _getStartedButton = _page.GetByRole(AriaRole.Link, new() { NameString = "Get started" });
        }

        // Metoda, która będzie klikać w przycisk "Get started".
        public async Task ClickGetStartedButtonAsync()
        {
            await _getStartedButton.ClickAsync();
        }
    }
}
