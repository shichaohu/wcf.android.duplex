using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Responder.Wcf.Service.Interface;

namespace Responder.Wcf.Service
{
    public class AndroidService : IAndroidService
    {
        private static Dictionary<string, OperationContext> _users = new Dictionary<string, OperationContext>();
        public bool Regist(string name,out string message)
        {
            var user = OperationContext.Current;
            if (_users.Keys.Contains(name))
            {
                message = "用户名已注册";
                return false;
            }

            message = "";
            return true;
        }

        public bool Logout(string name)
        {
            if (_users.Keys.Contains(name))
            {
                _users.Remove(name);
            }

            return true;
        }
        public string PrintString(string value)
        {
            return "your string:" + value;
        }

        public void NeedCallBack()
        {
            var callBackChannel = OperationContext.Current.GetCallbackChannel<IAndroidCallBack>();

            string backMessage = "这是回调消息！";
            callBackChannel.Show(backMessage);
        }

        public static void Close()
        {
            foreach(var user in _users.Values)
            {
                user.GetCallbackChannel<IAndroidCallBack>().Close();
            }
        }
    }
}
