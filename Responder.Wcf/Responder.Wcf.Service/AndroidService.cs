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
    }
}
