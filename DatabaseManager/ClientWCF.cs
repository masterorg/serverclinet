using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ScadaCommon;
using System.Threading;


namespace DatabaseManager
{
    sealed class ClientWCF
    {

        static void Main()
        {

            Thread.Sleep(3000);

            Uri tcpAddress = new Uri("net.tcp://localhost:4000/IDatabaseManager");
            NetTcpBinding bindig = new NetTcpBinding();

            ChannelFactory<IDatabaseManager> factory = new ChannelFactory<IDatabaseManager>(bindig,new EndpointAddress(tcpAddress));

            IDatabaseManager proxy = factory.CreateChannel();
            Tag tag = new Tag(10, DateTime.Now);
            TagInfo taginfo = new TagInfo("1", 1500, "Sine");

            proxy.AddTag(tag, taginfo);
            Console.WriteLine("Dodat je tag sa Id: "+taginfo.TagId);

            Console.ReadKey();
            proxy.RemoveTag("1");
        }
    }
}
