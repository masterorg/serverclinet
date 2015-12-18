using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ScadaCommon
{
    [ServiceContract]
    public interface IDatabaseManager
    {
        [OperationContract]
        void AddTag(Tag tag, TagInfo tagInfo);
        [OperationContract]
        void RemoveTag(string tagId);
        [OperationContract]
        void ToggleTagAutoManual(string tagId);
    }
}
