using System;
using System.ServiceModel;

namespace Service
{
    class Program
    {
        static void Main()
        {
            using (var host = new ServiceHost(typeof(Service)))
            {
                host.Open();

                Console.WriteLine("Service is running on {0}", host.BaseAddresses[0].AbsoluteUri);
                Console.WriteLine("To finish, press ENTER");
                Console.ReadLine();

                host.Close();
            }
        }
    }
}
