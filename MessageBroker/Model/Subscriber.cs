using MessageBroker.Model.Interfaces;
using System;

namespace MessageBroker.Model
{
    public class Subscriber : ISubscriber
    {
        public string SubscriberName { get; private set; }

        public Subscriber(string name)
        {
            SubscriberName = name;
        }

        public void PrintMessage(object sender, IMessage message)
        {
            Console.WriteLine(message.Content);
        }
    }
}
