using Microsoft.Playwright.NUnit;

namespace myNUnit.DevTest
{
    // Zamiast testu, to nasza klasa bazowa dziedziczy po PageTest
    public class TestBaseDev : PageTest
    {
        // Deklarujemy naszą stronę jako zmienną 'protected'. 
        // Oznacza to, że tylko klasy, które dziedziczą po TestBase, będą ją widzieć
        protected HomePage HomePage;

        // SetUp jest metodą, która uruchamia się przed każdym testem.
        [SetUp]
        public async Task BaseSetup()
        {
            // 1. Włączamy nagrywanie ZANIM wejdziemy na jakąkolwiek stronę!
            await Context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });


            await Page.GotoAsync("https://www.playwright.dev/");
            // Tworzymy obiekt naszej strony, który będzie widoczny w każdym teście
            HomePage = new HomePage(Page);
        }

        // [TearDown] uruchamia się po każdym [Test] (nawet jeśli test upadnie na asercji!)
        [TearDown]
        public async Task BaseTearDown()
        {
            //Pytamy NUnita: "Czy ten test przed chwilą upadł?"
            bool hasFailed = TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed;
            
            if (hasFailed)
            {
                // Pobieramy nazwę upadającego testu, żeby ładnie nazwać plik
                string testName = TestContext.CurrentContext.Test.Name;

                // Ustawiamy scieżkę do zapisu
                string tracePath = $"traces/trace-{testName}.zip";

                //zatrzymujemy nagrywanie i zapisujemy trace do pliku
                await Context.Tracing.StopAsync(new() { Path = tracePath });

                Console.WriteLine($"Trace saved to: {tracePath}");
            }
            else
            {
                // Jeśli test przeszedł, to po prostu zatrzymujemy nagrywanie bez zapisywania trace'a
                await Context.Tracing.StopAsync();
            }
        }


    }
}
