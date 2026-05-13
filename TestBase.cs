using Microsoft.Playwright.NUnit;

namespace myNUnit
{
    // Zamiast testu, to nasza klasa bazowa dziedziczy po PageTest
    public class TestBase : PageTest
    {
        // Deklarujemy naszą stronę jako zmienną 'protected'. 
        // Oznacza to, że tylko klasy, które dziedziczą po TestBase, będą ją widzieć
        protected HomePage HomePage;

        // SetUp jest metodą, która uruchamia się przed każdym testem.
        [SetUp]
        public async Task BaseSetup()
        {
            // Przechodzimy na stronę główną
            await Page.GotoAsync("https://www.playwright.dev/");
            // Tworzymy obiekt naszej strony, który będzie widoczny w każdym teście
            HomePage = new HomePage(Page);
        }

        // [TearDown] uruchamia się po każdym [Test] (nawet jeśli test upadnie na asercji!)
        [TearDown]
        public async Task BaseTearDown()
        {
            // Playwright zamyka przeglądarkę sam, ale to jest idealne miejsce na np.
            // robienie screenshotów w przypadku błędu, logowanie do konsoli czy czyszczenie bazy danych.
        }


    }
}
