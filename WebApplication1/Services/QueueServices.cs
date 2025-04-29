using Azure.Storage.Queues;

namespace WebApplication1.Services
{
    public class QueueServices : IQueueService
    {
        private readonly QueueClient _queueClient;

        public QueueServices(string connectionString, string queueName)
        {
            _queueClient = new QueueClient(connectionString, queueName);
            _queueClient.CreateIfNotExists();
        }

        public async Task<string> ReciveMessageAsync()
        {
            var messageRessponse = await _queueClient.ReceiveMessageAsync();
            if (messageRessponse.Value != null) 
            {
                string message=messageRessponse.Value.Body.ToString();

                return message;
            }

            return "";
        }

        public async Task SendMessageAsync(string message)
        {
            if (!string.IsNullOrEmpty(message)) 
            {
                await _queueClient.SendMessageAsync(message, TimeSpan.FromSeconds(15), TimeSpan.FromMinutes(10));
            }
        }
    }
}
