using System;
using DustInTheWind.BookStore;
using LogAccess;

namespace ObserverPatternDemo.WithCSharpEvents
{
    internal class NewspaperClient
    {
        private readonly string name;
        private readonly Log log;

        public NewspaperClient(string name, PrintingHouse printingHouse, Log log)
        {
            this.name = name;
            this.log = log;

            printingHouse.NewspaperPrinted += new EventHandler<Newspaper>(Notify);
        }

        private void Notify(object sender, Newspaper newspaper)
        {
            log.WriteAsClient(name, "Am primit ziarul: " + newspaper.Title + " " + newspaper.Number);
        }
    }
}