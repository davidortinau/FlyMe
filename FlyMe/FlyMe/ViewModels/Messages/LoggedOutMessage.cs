using System;
using TinyMessenger;

namespace FlyMe.ViewModels.Messages
{
    public class LoggedOutMessage : ITinyMessage
    {
        public LoggedOutMessage()
        {
        }

        public object Sender { get; private set; }
    }
}
