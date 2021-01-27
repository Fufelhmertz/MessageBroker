
namespace MessageBroker.Model.Interfaces
{
    public class Message : IMessage
    {
        public string Content { get; private set; }

        public Message(string mess)
        {
            Content = mess;
        }
    }
}
