using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ScadaCommon
{
    [DataContract]
    public class Tag
    {
        [DataMember]
        private double value;

                [DataMember]

        public double Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

                [DataMember]

        private DateTime timeStamp;
               [DataMember]

        public DateTime TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }

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
