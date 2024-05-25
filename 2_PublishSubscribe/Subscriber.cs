namespace PublishSubscribe
{
    public class Subscriber<T>
    {
        public Publisher<T> Publisher { get; private set; }
        public Subscriber(Publisher<T> publisher)
        {
            Publisher = publisher;
        }
    }
}
