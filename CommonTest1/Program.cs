
using CommonTest1;

public class Program
{
    public static void Main(string[] args)
    {
        NotificationFactory smsFactory = new SMSFactory();
        NotificationFactory emailFactory = new EmailFactory();
        List<User> users = new List<User>();

        User user1 = new User("John", smsFactory);
        users.Add(user1);
        User user2 = new User("Mary", emailFactory);
        users.Add(user2);

        foreach (User user in users)
        {
            user.SendMessage("Test message");
        }

        user1.Factory = emailFactory;

        foreach (User user in users)
        {
            user.SendMessage("Test message 2");
        }
    }
}
