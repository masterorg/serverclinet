using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ScadaCommon
{
    [ServiceContract]
    public interface IPicture
    {
        [OperationContract]
        Tag Read(string tagId);
        [OperationContract]
        void Write(string tagId, Tag tag);
    }
}
