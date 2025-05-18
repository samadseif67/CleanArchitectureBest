namespace SignalR_Server_App.Services
{
    public interface IMessageHubClient
    {
        Task SendOffersToUser(List<string> message);
        Task SendMessage(dynamic dataInput);
        Task SendNotification(string message);
    }
}
