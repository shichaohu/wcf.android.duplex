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
        string PrintString(string value);

        [OperationContract]
        void NeedCallBack();

    }

    public interface IAndroidCallBack
    {
        [OperationContract(IsOneWay = true)]
        void Show(string backMessage);
    }
}
