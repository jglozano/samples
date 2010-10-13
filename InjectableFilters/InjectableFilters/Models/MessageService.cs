namespace InjectableFilters.Models
{

    public class MessageService : IMessageService
    {
        public string GetMessage(string action)
        {
            return string.Format("I'm in action '{0}'!", action);
        }
    }
}