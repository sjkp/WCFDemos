using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfDuplexChatClient
{
    public class ChatCallbackHandler : Contract.IChatCallback, ChatService.IChatServiceCallback
    {

        public void MessageBroadcast(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
