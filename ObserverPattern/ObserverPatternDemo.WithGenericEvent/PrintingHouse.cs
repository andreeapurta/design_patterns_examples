using System;
using DustInTheWind.BookStore;
using LogAccess;
using ObserverPatternDemo.WithGenericEvent.Infrastructure;

namespace ObserverPatternDemo.WithGenericEvent
{
    internal class PrintingHouse
    {
        private readonly BookRepository bookRepository;
        private readonly Log log;
        private readonly NewspaperRepository newspaperRepository;

        public Event<Book> BookPrintedEvent { get; }

        public Event<Newspaper> NewspaperPrintedEvent { get; }

        public PrintingHouse(BookRepository bookRepository, Log log, NewspaperRepository newspaperRepository)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
            this.newspaperRepository = newspaperRepository ?? throw new ArgumentNullException(nameof(newspaperRepository));
            BookPrintedEvent = new Event<Book>();
            NewspaperPrintedEvent = new Event<Newspaper>();
        }

        public void PrintRandomBook()
        {
            Book generatedBook = bookRepository.GetOne();
            log.WriteAsPrintingHouse("Am tiparit o noua carte: " + generatedBook.Title);

            BookPrintedEvent.NotifySubscribers(generatedBook);
        }

        public void PrintNewspaper()
        {
            Newspaper newspaper = IssueNextNewspaper();
            log.WriteAsPrintingHouse("Am tiparit un nou ziar: " + newspaper.Title);

            NewspaperPrintedEvent.NotifySubscribers(newspaper);
        }

        private Newspaper IssueNextNewspaper()
        {
            Newspaper lastNewspaper = newspaperRepository.GetLast();
            int lastNewspaperNumber = lastNewspaper?.Number ?? 0;

            Newspaper nextNewspaper = new()
            {
                Number = lastNewspaperNumber + 1
            };

            newspaperRepository.Add(nextNewspaper);

            return nextNewspaper;
        }
    }
}