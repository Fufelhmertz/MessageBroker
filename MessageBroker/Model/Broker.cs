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

        /// <summary>
        /// Метод для рассылки сообщения всем подписантам
        /// </summary>        
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

        /// <summary>
        /// Метод для добавления нового подписанта к рассылке
        /// </summary>        
        public void Subscribe(ISubscriber subscriber)
        {
            if (subscribers.Contains(subscriber))
            {
                throw new Exception($"Подписчик {subscriber.SubscriberName} уже подписан на рассылку");
            }

            subscribers.Add(subscriber);
        }

        /// <summary>
        /// Метод удаления подписанта из рассыки
        /// </summary>   
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
