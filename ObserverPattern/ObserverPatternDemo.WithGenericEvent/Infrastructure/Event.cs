using System.Collections.Generic;

namespace ObserverPatternDemo.WithGenericEvent.Infrastructure
{
    internal class Event<TData>
    {
        private readonly List<ISubscriber<TData>> subscribers = new();
        
        public void Subscribe(ISubscriber<TData> subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void Unsubscribe(ISubscriber<TData> subscriber)
        {
            subscribers.Remove(subscriber);
        }

        public void NotifySubscribers(TData data)
        {
            foreach (ISubscriber<TData> subscriber in subscribers)
            {
                subscriber.Notify(data);
            }
        }
    }
}