using MessageBroker.Model.Interfaces;
using System;

namespace MessageBroker.Model
{
    public class Subscriber : ISubscriber
    {
        public string SubscriberName { get; private set; }

        public string LastMessage { get; private set; }

        public Subscriber(string name)
        {
            SubscriberName = name;
        }

        public void PrintMessage(object sender, IMessage message)
        {
            LastMessage = message.Content;

            Console.WriteLine(message.Content);
        }
    }
}
