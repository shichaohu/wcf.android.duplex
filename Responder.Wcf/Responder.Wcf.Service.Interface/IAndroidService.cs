using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Responder.Wcf.Service.Interface
{
    [ServiceContract(CallbackContract = typeof(IAndroidCallBack))]
    public interface IAndroidService
    {
        [OperationContract]
        bool Regist(string name,out string message);

        [OperationContract]
        bool Logout(string name);
        [OperationContract]
        string PrintString(string value);

        [OperationContract]
        void NeedCallBack();

    }

    public interface IAndroidCallBack
    {
        [OperationContract(IsOneWay = true)]
        void Show(string backMessage);
        [OperationContract(IsOneWay = true)]
        void Close();
    }
}
