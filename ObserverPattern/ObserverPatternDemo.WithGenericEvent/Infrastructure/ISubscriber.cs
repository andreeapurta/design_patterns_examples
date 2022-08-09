namespace ObserverPatternDemo.WithGenericEvent.Infrastructure
{
    internal interface ISubscriber<in TData>
    {
        void Notify(TData data);
    }
}