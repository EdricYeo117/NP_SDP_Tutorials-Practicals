using System;
using System.Collections.Generic;

// Abstract Factory Interface
public interface NotificationFactory
{
    INotification CreateNotification();
}

// Concrete Factory for SMS
public class SMSFactory : NotificationFactory
{
    public INotification CreateNotification()
    {
        return new SMSNotification();
    }
}

// Concrete Factory for Email
public class EmailFactory : NotificationFactory
{
    public INotification CreateNotification()
    {
        return new EmailNotification();
    }
}

// Notification Interface (Product)
public interface INotification
{
    void Send(string message, string userName);
}

// SMS Notification Implementation
public class SMSNotification : INotification
{
    public void Send(string message, string userName)
    {
        Console.WriteLine($"Sending SMS to {userName}: {message}");
    }
}

// Email Notification Implementation
public class EmailNotification : INotification
{
    public void Send(string message, string userName)
    {
        Console.WriteLine($"Sending Email to {userName}: {message}");
    }
}

// User Class
public class User
{
    public string Name { get; private set; }
    public NotificationFactory Factory { get; set; }

    public User(string name, NotificationFactory factory)
    {
        Name = name;
        Factory = factory;
    }

    public void SendMessage(string message)
    {
        var notification = Factory.CreateNotification();
        notification.Send(message, Name);
    }
}

// Program Entry Point
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

        Console.WriteLine("First Message:");
        foreach (User user in users)
        {
            user.SendMessage("Test message");
        }

        Console.WriteLine("\nUpdating John's notification method to Email...");
        user1.Factory = emailFactory;

        Console.WriteLine("\nSecond Message:");
        foreach (User user in users)
        {
            user.SendMessage("Test message 2");
        }
    }
}
