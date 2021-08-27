namespace MoqMvc.Services
{
    public interface IMessage
    {
        void Sms(string message, int userid);
        void Email(string message, int userid);
        void Notif(string message, int userid);
       
    }
}
