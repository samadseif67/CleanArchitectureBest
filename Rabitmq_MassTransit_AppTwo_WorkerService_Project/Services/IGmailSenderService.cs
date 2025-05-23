using namespaceSendGmailCommand;

namespace Rabitmq_MassTransit_AppTwo_WorkerService_Project.Services
{
    public interface IGmailSenderService
    {
        Task SendGmail(SendGmailCommand sendGmails);
    }
}