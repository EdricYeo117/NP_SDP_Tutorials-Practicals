using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTest1
{
    // Abstract Factory Interface
    public interface NotificationFactory
    {
        Notification CreateNotification();
    }
}
