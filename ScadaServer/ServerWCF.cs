using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ServiceModel;
using ScadaCommon;
using System.IO;
using System.Xml.Serialization;


namespace ScadaServer
{
    internal sealed class ServerWCF
    {
        

        private static void Main()
        {
            Console.WriteLine("WCFServer kreiran.");
            ScadaModel model = new ScadaModel();
            

            if (File.Exists("database.txt"))
            { 
                
            }

            Uri htppAdrress = new Uri("http://localhost:8000/IPicture");
            Uri tcpAddress = new Uri("net.tcp://localhost:4000/IDatabaseManager");

            BasicHttpBinding bindig1 = new BasicHttpBinding();
            NetTcpBinding bindig2 = new NetTcpBinding();
            ServiceHost svc = new ServiceHost(model);


            svc.AddServiceEndpoint(typeof(IPicture),bindig1,htppAdrress);
            svc.AddServiceEndpoint(typeof(IDatabaseManager),bindig2,tcpAddress);

            svc.Open();

            Console.WriteLine("WCFServer spreman za primanje poruka.");

            Console.ReadLine();
          
            svc.Close();

           

        }
       

        

        
    }

   
}
