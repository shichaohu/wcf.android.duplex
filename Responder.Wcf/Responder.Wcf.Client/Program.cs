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
            string name = "shi";
            
            using (var proxy = new DuplexChannelFactory<IAndroidService>("AndroidService"))
            {
                proxy.Opening+= (sender, e) => Console.WriteLine("通道开启..");
                proxy.Closed += (sender, e) => Console.WriteLine("通道关闭..");

                var callBack = new AndroidCallBack();
                callBack.CallBackEvent += Close;
                InstanceContext instanceContext = new InstanceContext(callBack);
                var channel = proxy.CreateChannel(instanceContext);

                string message;
                channel.Regist(name, out message);
                channel.PrintString("hello world");
                channel.NeedCallBack();
                
                Console.WriteLine("输入quit退出");
                string input = Console.ReadLine();
                while (input.ToLower() != "quit")
                {
                    input = Console.ReadLine();
                }

                channel.Logout(name);
            }
        }

        private static void Close()
        {
            Console.WriteLine("服务器已关闭..");
        }
    }

    class AndroidCallBack:IAndroidCallBack
    {
        public delegate void CallBackEventHandler();
        public event CallBackEventHandler CallBackEvent;
        public void Show(string backMessage)
        {
            Console.WriteLine(string.Format("回调信息为：{0}", backMessage));
        }

        public void Close()
        {
            if (CallBackEvent != null)
            {
                CallBackEvent();
            }
        }
    }
}
