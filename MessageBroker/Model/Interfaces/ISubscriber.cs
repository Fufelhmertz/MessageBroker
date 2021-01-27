
namespace MessageBroker.Model.Interfaces
{
    public interface ISubscriber
    {
        string SubscriberName { get; }
        void PrintMessage(object sender, IMessage message);
    }
}
