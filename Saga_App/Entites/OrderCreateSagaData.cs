using Rebus.Sagas;

namespace Saga_App.Entites
{
    public class OrderCreateSagaData : ISagaData
    {
        public Guid Id { get; set; }
        public int Revision { get; set; }

        public Guid OrderId { get; set; }

        
        public bool PaymentRequrstSent { get; set; }
        public bool ConfirmationEmailSent { get;set; }

    }
}
