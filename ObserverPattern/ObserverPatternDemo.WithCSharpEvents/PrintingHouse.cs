using System;
using DustInTheWind.BookStore;
using LogAccess;

namespace ObserverPatternDemo.WithCSharpEvents
{
    internal class PrintingHouse
    {
        private readonly BookRepository bookRepository;
        private readonly Log log;
        private readonly NewspaperRepository newspaperRepository;

        public event EventHandler<Book> BookPrinted;
        public event EventHandler<Newspaper> NewspaperPrinted;

        public PrintingHouse(BookRepository bookRepository, Log log, NewspaperRepository newspaperRepository)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
            this.newspaperRepository = newspaperRepository ?? throw new ArgumentNullException(nameof(newspaperRepository));
        }

        public void PrintRandomBook()
        {
            Book generatedBook = bookRepository.GetOne();
            log.WriteAsPrintingHouse("Am tiparit o noua carte: " + generatedBook.Title);

            OnBookPrinted(generatedBook);
        }

        public void PrintNewspaper()
        {
            Newspaper newspaper = IssueNextNewspaper();
            log.WriteAsPrintingHouse("Am tiparit un nou ziar: " + newspaper.Title);

            OnNewspaperPrinted(newspaper);
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

        protected virtual void OnBookPrinted(Book generatedBook)
        {
            BookPrinted?.Invoke(this, generatedBook);
        }

        protected virtual void OnNewspaperPrinted(Newspaper newspaper)
        {
            NewspaperPrinted?.Invoke(this, newspaper);
        }
    }
}