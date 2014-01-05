using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WcfDuplexChat
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start a new chat server.
            using(var host = new ServiceHost(typeof(ChatService)))
            {
                host.Open();
                Console.WriteLine("Chat server running " + string.Join(", ", host.Description.Endpoints.Select(s => s.Address)));
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
            
        }
    }
}
