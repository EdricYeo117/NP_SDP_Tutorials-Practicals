using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTest1
{
    public class Email : Notification
    {
        public void Send(string message, string userName)
        {
            Console.WriteLine($"Sending to {userName} - Email: \"{message}\"");
        }
    }
}
