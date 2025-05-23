using namespaceSendGmailCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabitmq_MassTransit_AppTwo_WorkerService_Project.Services
{

    public partial class GmailSenderService : IGmailSenderService
    {
        private readonly ILogger<GmailSenderService> _logger;
        public GmailSenderService(ILogger<GmailSenderService> logger)
        {
            _logger= logger;
        }
        public async Task SendGmail(SendGmailCommand sendGmails)
        {
           
            _logger.LogInformation("Send Gmail ....samad..."+ sendGmails.Body, sendGmails);

        }

    }
}
