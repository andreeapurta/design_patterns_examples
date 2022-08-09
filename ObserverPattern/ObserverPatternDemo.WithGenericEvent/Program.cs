using DustInTheWind.BookStore;
using LogAccess;

namespace ObserverPatternDemo.WithGenericEvent
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Log log = new();
            BookStoreDbContext bookStoreDbContext = new();
            BookRepository bookRepository = new(bookStoreDbContext);
            NewspaperRepository newspaperRepository = new(bookStoreDbContext);

            PrintingHouse printingHouse = new(bookRepository, log, newspaperRepository);

            BookClient george = new("George", printingHouse, log);
            BookClient ana = new("Ana", printingHouse, log);

            printingHouse.PrintRandomBook();

            george.UnsubscribeFromBooks();
            printingHouse.PrintRandomBook();

            NewspaperClient alex = new("Alex", printingHouse, log);
            printingHouse.PrintNewspaper();
        }
    }
}