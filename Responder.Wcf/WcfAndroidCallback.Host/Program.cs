using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfAndroidCallback.Service;

namespace WcfAndroidCallback.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(AndroidService)))
            {
                host.Opened += (sender, e) => Console.WriteLine("服务开启..");
                host.Open();

                Console.WriteLine("输入quit退出");
                string input = Console.ReadLine();
                while (input.ToLower() != "quit")
                {
                    input = Console.ReadLine();
                }
            }
        }
    }
}
