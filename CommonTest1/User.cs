using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTest1
{
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
}
