using System;
using TinyMessenger;

namespace FlyMe.ViewModels.Messages
{
    public class LoggedInMessage : ITinyMessage
    {
        public LoggedInMessage()
        {
        }

        public object Sender { get; private set; }
    }
}
