using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTest1
{
    public interface Notification
    {
        void Send(string message, string userName);
    }
}
