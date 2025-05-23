using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Rabitmq_MassTransit_AppTwo_WorkerService_Project.Services.GmailSenderService;

namespace Rabitmq_MassTransit_AppTwo_WorkerService_Project.Services
{
    public class GmailConsumer : IConsumer<SendGmailCommand>
    {

        private readonly IGmailSenderService _gmailSenderService;
        public GmailConsumer(IGmailSenderService gmailSenderService)
        {
            _gmailSenderService = gmailSenderService;
        }

        public async Task Consume(ConsumeContext<SendGmailCommand> context)
        {
            var message = context.Message;
            await _gmailSenderService.SendGmail(message);           
        }
    }
}
