namespace WebApplication1.Services
{
    public interface IQueueService
    {
        Task SendMessageAsync(string message);
        Task<string> ReciveMessageAsync();
    }
}
