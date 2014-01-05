using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Contract
{
    [ServiceContract(SessionMode=SessionMode.Required, CallbackContract=typeof(IChatCallback))]
    public interface IChatService
    {
        [OperationContract(IsOneWay=true,IsInitiating=true)]
        void Register();
        [OperationContract(IsOneWay=true,IsInitiating=false)]
        void Send(string message);
    }
}
