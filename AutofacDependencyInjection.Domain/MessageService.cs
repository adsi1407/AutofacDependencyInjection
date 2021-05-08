namespace AutofacDependencyInjection.Domain
{
    public class MessageService
    {
        private readonly IMessageRepository messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public void SaveMessage(string message)
        {
            messageRepository.SaveMessage(message);
        }
    }
}
