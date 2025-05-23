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
            logger = _logger;
        }
        public async Task SendGmail(SendGmailCommand sendGmails)
        {
            await Task.Delay(1000);
            _logger.LogInformation("Send Gmail ....", sendGmails);

        }

    }
}
