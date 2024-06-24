using MassTransit;
using OrderPublish.Model;

namespace ConsumerAPI
{
    public class MessageConsumer : IConsumer<Message>
    {
        private static readonly List<string> _messages = new List<string>();

        public Task Consume(ConsumeContext<Message> context)
        {
            _messages.Add(context.Message.Text);
            Console.WriteLine($"Received message: {context.Message.Text}");
            return Task.CompletedTask;
        }

        public static List<string> GetMessages()
        {
            return _messages;
        }
    }
}
