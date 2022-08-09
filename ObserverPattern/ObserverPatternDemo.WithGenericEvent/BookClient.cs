using DustInTheWind.BookStore;
using LogAccess;
using ObserverPatternDemo.WithGenericEvent.Infrastructure;

namespace ObserverPatternDemo.WithGenericEvent
{
    internal class BookClient : ISubscriber<Book>
    {
        private readonly Log log;
        private readonly string name;
        private readonly PrintingHouse printingHouse;

        public BookClient(string name, PrintingHouse printingHouse, Log log)
        {
            this.log = log;
            this.name = name;
            this.printingHouse = printingHouse;

            printingHouse.BookPrintedEvent.Subscribe(this);
        }

        public void Notify(Book book)
        {
            log.WriteAsClient(name, "Am primit cartea: " + book.Title);
        }

        public void UnsubscribeFromBooks()
        {
            printingHouse.BookPrintedEvent.Unsubscribe(this);
        }
    }
}