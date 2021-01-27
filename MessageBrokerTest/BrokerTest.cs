using MessageBroker.Model.Interfaces;
using MessageBroker.Model;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;
using FluentAssertions;

namespace MessageBrokerTest
{
    [ExcludeFromCodeCoverage]
    public class BrokerTest
    {
        private IBroker broker;
        private ISubscriber subscriber;
        public BrokerTest()
        {
            broker = new Broker();
            subscriber = new Subscriber("TestUser");
        }

        [Fact]
        public void Post_IncorrectMessage_ReturnThrow()
        {
            Action action = () => broker.Post(null);

            action.Should()
                .Throw<ArgumentNullException>()
                .WithMessage($"Value cannot be null. (Parameter 'Сообщение пусто')");
        }

        [Fact]
        public void Post_EmptyListSubscribers_ReturnThrow()
        {
            IMessage mess = new Message("test");

            Action action = () => broker.Post(mess);
            action.Should()
                .Throw<ArgumentNullException>()
                .WithMessage($"Value cannot be null. (Parameter 'На рассылку никто не подписан')");
        }

        [Fact]
        public void Post_CorrectRequest()
        {
            IMessage mess = new Message("test");
            broker.Subscribe(subscriber);

            broker.Post(mess);

            Console.Out.Should().NotBeNull();
            Console.Out.Should().Equals("test");
        }

        [Fact]
        public void Subscribe_DoublicateSubscribers_ReturnThrow()
        {
            IMessage mess = new Message("test");
            broker.Subscribe(subscriber);

            Action action = () => broker.Subscribe(subscriber);

            action.Should()
                .Throw<Exception>()
                .WithMessage($"Подписчик TestUser уже подписан на рассылку");
        }

        [Fact]
        public void UnSubscribe_EmptySubscribers_ReturnThrow()
        {
            Action action = () => broker.UnSubscribe(subscriber);

            action.Should()
                .Throw<Exception>()
                .WithMessage($"Подписчик TestUser не подписан на рассылку");
        }
    }
}
