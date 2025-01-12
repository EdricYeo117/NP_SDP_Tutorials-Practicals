using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTest1
{
    // Concrete Factory for SMS
    public class SMSFactory : NotificationFactory
    {
        public Notification CreateNotification()
        {
            return new SMS();
        }
    }
}
