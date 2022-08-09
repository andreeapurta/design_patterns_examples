using DustInTheWind.BookStore;
using LogAccess;
using ObserverPatternDemo.WithGenericEvent.Infrastructure;

namespace ObserverPatternDemo.WithGenericEvent
{
    internal class NewspaperClient : ISubscriber<Newspaper>
    {
        private readonly string name;
        private readonly Log log;

        public NewspaperClient(string name, PrintingHouse printingHouse, Log log)
        {
            this.name = name;
            this.log = log;

            printingHouse.NewspaperPrintedEvent.Subscribe(this);
        }

        public void Notify(Newspaper newspaper)
        {
            log.WriteAsClient(name, "Am primit ziarul: " + newspaper.Title + " " + newspaper.Number);
        }
    }
}