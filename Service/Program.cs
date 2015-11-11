using System;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using CaptureBehavior;

namespace Service
{
    class Program
    {
        static void Main()
        {
            using (var host = new ServiceHost(typeof(Service)))
            {
                var behavior = new CaptureBehavior.CaptureBehavior();
                host.Description.Behaviors.Add(behavior);

                host.Open();

                // Подписываемся на события 
                foreach (ChannelDispatcher dispatcher in host.ChannelDispatchers)
                {
                    foreach (var endPoint in dispatcher.Endpoints)
                    {
                        var query = (from ex in endPoint.DispatchRuntime.MessageInspectors
                            where ex.GetType() == typeof (Inspector)
                            select ex).Cast<Inspector>();

                        foreach (var item in query)
                        {
                            item.RaiseRequestReceived += (sender, args) =>
                            {
                                File.WriteAllText("request.xml", args.Message);
                                Console.WriteLine("Request write to request.xml");
                            };
                            item.RaiseSendingReply += (sender, args) =>
                            {
                                File.WriteAllText("response.xml", args.Message);
                                Console.WriteLine("Response write to response.xml");
                            };

                        }
                    }
                }

                Console.WriteLine("Service is running on {0}", host.BaseAddresses[0].AbsoluteUri);
                Console.WriteLine("To finish, press ENTER");
                Console.ReadLine();

                host.Close();
            }
        }
    }
}
