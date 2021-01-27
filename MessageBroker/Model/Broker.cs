using MessageBroker.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageBroker.Model
{
    public class Broker : IBroker
    {
        private readonly List<ISubscriber> subscribers;
        public Broker()
        {
            subscribers = new List<ISubscriber>();
        }

        public void Post(IMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("Сообщение пусто");
            }

            if (!subscribers.Any())
            {
                throw new ArgumentNullException("На рассылку никто не подписан");
            }

            subscribers.ForEach(x => x.PrintMessage(this, message));
        }

        public void Subscribe(ISubscriber subscriber)
        {
            if (subscribers.Contains(subscriber))
            {
                throw new Exception($"Подписчик {subscriber.SubscriberName} уже подписан на рассылку");
            }

            subscribers.Add(subscriber);
        }

        public void UnSubscribe(ISubscriber subscriber)
        {
            if (!subscribers.Contains(subscriber))
            {
                throw new Exception($"Подписчик {subscriber.SubscriberName} не подписан на рассылку");
            }

            subscribers.Remove(subscriber);
        }
    }
}
