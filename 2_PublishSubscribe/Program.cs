using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublishSubscribe
{
    class Program
    {
        private static Publisher<string> publisher;
        private static Subscriber<string> subscriber;

        static void Main(string[] args)
        {
            Console.WriteLine("=== Application started ===");

            publisher = new Publisher<string>();
            subscriber = new Subscriber<string>(publisher);

            subscriber.Publisher.DataPublisher += publisher_DataPublisher;

            publisher.Started("Started");
            publisher.Completed("Completed");

            Console.WriteLine("Press Enter to close this window.");
            Console.ReadLine();
        }

        private static void publisher_DataPublisher(object sender, MessageArgument<string> e)
        {
            Console.WriteLine("Subscriber: " + e.Message);
        }
    }
}
