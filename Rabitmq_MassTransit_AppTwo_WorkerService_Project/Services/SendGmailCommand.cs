namespace Rabitmq_MassTransit_AppTwo_WorkerService_Project.Services
{ 
        public class SendGmailCommand
        {
            public string To { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
        }
     
}
