using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Contract
{
    public interface IChatCallback
    {
        [OperationContract(IsOneWay=true)]
        void MessageBroadcast(string msg);
    }
}
