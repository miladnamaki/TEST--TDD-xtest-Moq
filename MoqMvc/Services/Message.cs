namespace MoqMvc.Services
{
    public class Message : IMessage
    {
        private readonly IMessage _mess;

        public Message(IMessage mess)
        {
            _mess = mess;
        }

        public void Email(string message, int userid)
        {
            throw new System.NotImplementedException();
        }

        public void Sms(string message, int userid)
        {
            throw new System.NotImplementedException();
        }

        public void Notif(string message, int userid)
        {
            throw new System.NotImplementedException();
        }

        public enum MEssageType
        {
            Sms,
            Email,
            Notif
        }
    }
}
