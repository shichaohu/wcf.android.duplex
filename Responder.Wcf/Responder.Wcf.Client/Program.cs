using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Responder.Wcf.Service.Interface;
using System.Threading;

namespace Responder.Wcf.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(1000);

            InstanceContext instanceContext = new InstanceContext(new AndroidCallBack());
            using (var proxy = new DuplexChannelFactory<IAndroidService>(instanceContext, "AndroidService"))
            {
                proxy.Opening+= (sender, e) => Console.WriteLine("通道开启..");
                proxy.Closed += (sender, e) => Console.WriteLine("通道关闭..");
                
                proxy.Open();
                var androidService = proxy.CreateChannel();
                androidService.PrintString("hello world");
                androidService.NeedCallBack();

                Console.ReadLine();
            }
        }
    }

    class AndroidCallBack:IAndroidCallBack
    {
        public void Show(string backMessage)
        {
            Console.WriteLine(string.Format("回调信息为：{0}", backMessage));
        }
    }
}
