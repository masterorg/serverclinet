using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ScadaCommon
{

    [DataContract]
    public class TagInfo
    {
        [DataMember]
        private string tagId;
        [DataMember]
        private int scanTime;
        [DataMember]
        private string functionType;

        public string TagId
        {

            get { return tagId; }

            set { tagId = value; }

        }

        public int ScanTime
        {

            get { return scanTime; }

            set { scanTime = value; }

        }

        public string FunctionType
        {

            get { return functionType; }

            set { functionType = value; }

        }

        public TagInfo(string tagId, int scanTime, string functionType)
        {

            this.tagId = tagId;

            this.scanTime = scanTime;

            this.functionType = functionType;

        }

    }
}
