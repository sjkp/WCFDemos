using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WcfDuplexChat
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single
        //, ConcurrencyMode=ConcurrencyMode.Reentrant
        )] 
    public class ChatService : IChatService
    {
        List<string> messages = new List<string>();
        List<IChatCallback> clients = new List<IChatCallback>();

        public void Send(string message)
        {
            messages.Add(message);
            foreach(var client in clients)
            {
                if (client != Callback)
                {
                    client.MessageBroadcast(message);
                }
                //If the service is calling the caller, then the service has to have ConcurrencyMode.Rentrant or Multiple otherwise a deadlock will happen.
                //else
                //{
                //    client.MessageBroadcast(message);
                //}
            }            
        }

        IChatCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IChatCallback>();
            }
        }

        public void Register()
        {
            clients.Add(Callback);            
        }
    }
}
