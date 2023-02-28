using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace СSharpLB4
{
    public class MessageBroker
    {
        private static readonly MessageBroker s_messageBroker = new MessageBroker();
        private MessageBroker()
        {
        }

        public static MessageBroker GetInstance()
        {
            return s_messageBroker;
        }

        public void RaiseMessage(string message)
        {
            MessageBox.Show(message, "Message");
        }
    }
}
