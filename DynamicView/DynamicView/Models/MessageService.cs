namespace DynamicView.Models
{
    public class MessageService : IMessageService
    {
        public string GetWelcomeMessage()
        {
            return "Welcome to ASP.NET MVC!";
        }
    }
}
