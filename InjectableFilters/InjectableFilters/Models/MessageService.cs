namespace InjectableFilters.Models
{

    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "I'm from a service!";
        }

        public string GetMessage(string action)
        {
            return string.Format("I'm in action '{0}'!", action);
        }
    }
}