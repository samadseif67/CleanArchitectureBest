namespace Rabitmq_MassTransit_AppOne.Modals
{
    public class SendGmailCommand
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

}
