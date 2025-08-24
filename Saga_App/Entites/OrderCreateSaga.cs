using Rebus.Bus;
using Rebus.Handlers;
using Rebus.Sagas;

namespace Saga_App.Entites
{
    public class OrderCreateSaga : Saga<OrderCreateSagaData>,
        IAmInitiatedBy<OrderCreateEvent>,
        IHandleMessages<OrderConfirmationEmailSent>,
        IHandleMessages<OrderPaymentRequrstSent>
    {
        private readonly IBus _bus;
        public OrderCreateSaga(IBus bus)
        {
            _bus=bus;
        }



        public async Task Handle(OrderCreateEvent message)
        {
            if (!IsNew)
            {
                return;
            }
            await _bus.Send(new SendOrderConfirmtionEmail(message.orederId));
        }

        public async Task Handle(OrderConfirmationEmailSent message)
        {
            Data.ConfirmationEmailSent = true;
            await _bus.Send(new CreateOrderPaymentRequest(message.orederId));
        }

        public Task Handle(OrderPaymentRequrstSent message)
        {
            Data.PaymentRequrstSent = true;
            MarkAsComplete();
            return Task.CompletedTask;
        }

        protected override void CorrelateMessages(ICorrelationConfig<OrderCreateSagaData> config)
        {
            config.Correlate<OrderCreateEvent>(x => x.orederId, x => x.OrderId);
            config.Correlate<OrderConfirmationEmailSent>(x => x.orederId, x => x.OrderId);
            config.Correlate<OrderPaymentRequrstSent>(x => x.orederId, x => x.OrderId);
        }
    }
}
