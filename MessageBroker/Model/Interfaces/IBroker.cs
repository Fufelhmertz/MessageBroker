
namespace MessageBroker.Model.Interfaces
{
    public interface IBroker
    {
        void Post(IMessage message);
        void Subscribe(ISubscriber subscriber);
        void UnSubscribe(ISubscriber subscriber);
    }
}
