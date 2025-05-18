using Microsoft.AspNetCore.SignalR;

namespace SignalR_Server_App.Services
{
    public class MessageHub: Hub<IMessageHubClient>
    {
        public async Task SendOffersToUser(List<string> message)
        {
            await Clients.All.SendOffersToUser(message);
        }

        public class cstomer
        {
            public string customerName { get; set; }
            public string foodName { get; set; }
        }
        public async Task SendMessage(cstomer dataInput)
        {
            var data = new
            {
                customerName = dataInput.customerName,
                foodName = dataInput.foodName
            };
          await  Clients.All.SendMessage(data);
            //await Clients.All.SendAsync("ReceiveMessage", data);//به تمام کاربران پیام مورد نظر را ارسال کن
                                                                // await Clients.Caller.SendAsync("ReceiveMessage", data);//فقط به همین ارسال کننده پیام این پیام ارسال شود
                                                                // await Clients.Others.SendAsync("ReceiveMessage", data);//به تمام کلاینت ها پیام ارسال شود بجز خود ارسال کننده
        }


        public async Task SendNotification(string message)
        {
            await Clients.All.SendNotification(message);
           // await Clients.All.SendAsync("ReceiveNotification", message);
        }



    }
}
