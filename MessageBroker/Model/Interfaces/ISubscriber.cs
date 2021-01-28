
namespace MessageBroker.Model.Interfaces
{
    public interface ISubscriber
    {
        string SubscriberName { get; }
        string LastMessage { get; }
        void PrintMessage(object sender, IMessage message);
    }
}
