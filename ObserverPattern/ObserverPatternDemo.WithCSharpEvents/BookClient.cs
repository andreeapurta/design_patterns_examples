using System;
using DustInTheWind.BookStore;
using LogAccess;

namespace ObserverPatternDemo.WithCSharpEvents
{
    internal class BookClient
    {
        private readonly Log log;
        private readonly string name;
        private readonly PrintingHouse printingHouse;

        public BookClient(string name, PrintingHouse printingHouse, Log log)
        {
            this.log = log;
            this.name = name;
            this.printingHouse = printingHouse;

            printingHouse.BookPrinted += new EventHandler<Book>(Notify);
        }

        private void Notify(object sender, Book book)
        {
            log.WriteAsClient(name, "Am primit cartea: " + book.Title);
        }

        public void UnsubscribeFromBooks()
        {
            printingHouse.BookPrinted -= new EventHandler<Book>(Notify);
        }
    }
}