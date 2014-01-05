using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WcfDuplexChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Let user input port, so multiple chat clients can run on same machine.
            int port = 12001;
            if (args.Length < 1)
            {
                Console.WriteLine("Enter port number");
                port = int.Parse(Console.ReadLine());
            }
            else
            {
                port = int.Parse(args[0]);
            }
            var instanceContext = new InstanceContext(new ChatCallbackHandler());
            var binding = new WSDualHttpBinding();
            binding.ClientBaseAddress = new Uri(string.Format("http://localhost:{0}/ChatClient",port));
            var endpoint = new EndpointAddress("http://localhost:12000/ChatServer");
            //using(var client = new ChatService.ChatServiceClient(instanceContext,binding, endpoint)) //Visual Studio generated client proxy. 
            using(var factory = new DuplexChannelFactory<Contract.IChatService>(instanceContext, binding, endpoint)) //Channelfactory create by hand.
            {
                var client = factory.CreateChannel();
                try
                {
                    //client.Open();
                    client.Register();
                    Console.WriteLine("Chat client ready running on " + binding.ClientBaseAddress);
                    do
                    {
                        var message = Console.ReadLine();
                        client.Send(message);
                    } while (true);
                } catch(Exception ex)
                {
                    Console.Write(ex.ToString());
                }
            }
            Console.ReadKey();

        }
    }
}
