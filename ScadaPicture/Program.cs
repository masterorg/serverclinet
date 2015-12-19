using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScadaCommon;
using System.Threading;
using System.ServiceModel;

namespace ScadaPicture
{
    class Program
    {
        static void Main(string[] args)
        {

            Thread.Sleep(4000);

            Uri htppAdrress = new Uri("http://localhost:8000/IPicture");
            BasicHttpBinding bindig1 = new BasicHttpBinding();

            ChannelFactory<IPicture> factory = new ChannelFactory<IPicture>(bindig1,new EndpointAddress(htppAdrress));
            IPicture proxy = factory.CreateChannel();

            Tag tag = proxy.Read("1");
            if(tag!=null)
            Console.WriteLine("Value of tag is: " + tag.Value);
            Console.ReadKey();

        }
    }
}
