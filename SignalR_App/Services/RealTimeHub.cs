using Microsoft.AspNetCore.SignalR;

namespace SignalR_App.Services
{
    public class RealTimeHub : Hub
    {



        public async Task SendMessage(string customerName, string foodName)
        {
            var data = new
            {
                customerName = customerName,
                foodName = foodName
            };
            await Clients.All.SendAsync("ReceiveMessage", data);//به تمام کاربران پیام مورد نظر را ارسال کن
           // await Clients.Caller.SendAsync("ReceiveMessage", data);//فقط به همین ارسال کننده پیام این پیام ارسال شود
          // await Clients.Others.SendAsync("ReceiveMessage", data);//به تمام کلاینت ها پیام ارسال شود بجز خود ارسال کننده
        }


        public async Task SendNotification(string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", message);
        }




        //when user close window website or exit from website
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }


        //when user enter a website
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }





    }
}
