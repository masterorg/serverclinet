using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ScadaCommon
{
    [DataContract]
    public class Tag
    {
        [DataMember]
        private double value;

        [DataMember]
        private DateTime timeStamp;

        public Tag() { }

        public Tag(double value, DateTime timeStamp)
        {

            this.value = value;

            this.timeStamp = timeStamp;

        }

        public override string ToString()
        {

            return string.Format("{0}; {1};", value, timeStamp);

        }

    }
}
