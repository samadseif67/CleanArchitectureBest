
using Rebus.Bus;
using Rebus.Handlers;

public record OrderCreateEvent(Guid orederId);
public record OrderConfirmationEmailSent(Guid orederId);
public record OrderPaymentRequrstSent(Guid orederId);


public record SendOrderConfirmtionEmail(Guid orederId);
public record CreateOrderPaymentRequest(Guid orederId);


//***********************************************************************************************************************
public class SendOrderConfirmtionEmailHandeler : IHandleMessages<SendOrderConfirmtionEmail>
{
    private readonly ILogger _logger;
    private readonly IBus _bus;
    public SendOrderConfirmtionEmailHandeler(ILogger logger, IBus bus)
    {
        _logger = logger;
        _bus = bus;
    }

    public async Task Handle(SendOrderConfirmtionEmail message)
    {
        _logger.LogInformation("start order {@orederId}", message.orederId);
        await Task.Delay(2000);
        _logger.LogInformation("end order {@orederId}", message.orederId);
        await _bus.Send(new OrderConfirmationEmailSent(message.orederId));
    }
}
//*****************************************************************************************************************************

public class CreateOrderPaymentRequestHandler : IHandleMessages<CreateOrderPaymentRequest>
{
    private readonly ILogger _logger;
    private readonly IBus _bus;
    public CreateOrderPaymentRequestHandler(ILogger logger, IBus bus)
    {
        _logger = logger;
        _bus = bus;
    }

    public async Task Handle(CreateOrderPaymentRequest message)
    {
        _logger.LogInformation("sending payment {@orederId}", message.orederId);
         await Task.Delay(2000);
        _logger.LogInformation("ending payment {@orederId}", message.orederId);
        await _bus.Send(new OrderPaymentRequrstSent(message.orederId));

    }
}
  
//***************************************************************************************************************************
