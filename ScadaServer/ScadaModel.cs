using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScadaCommon;
using System.Threading;
using System.ServiceModel;
using System.Xml.Serialization;
using System.IO;


namespace ScadaServer
{
     [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
   public class ScadaModel:IPicture,IDatabaseManager
    {
        private Dictionary<String, Tag> tags;
        private Dictionary<String, Thread> threads;
        private Dictionary<String, TagInfo> infos;

        public Dictionary<String, TagInfo> Infos
        {
            get { return infos; }
            set { infos = value; }
        }

        public Dictionary<String, Thread> Threads
        {
            get { return threads; }
            set { threads = value; }
        }


        public Dictionary<String, Tag> Tags
        {
            get { return tags; }
            set { tags = value; }
        }

         //constructor
        public ScadaModel()
        {
            tags = new Dictionary<string, Tag>();
            threads = new Dictionary<string, Thread>();
            infos = new Dictionary<string, TagInfo>();
        
        }

       

         //interface implementation
        public Tag Read(string tagId)
        {
            Tag t=null;
            lock (tags)
            {
                if(tags.ContainsKey(tagId))
                t = tags[tagId];
            }

            return t;
        }

        public void Write(string tagId, Tag tag)
        {
            lock (tags)
            {
                tags[tagId] = tag;
            }

            Console.WriteLine(tags[tagId]);
        }

        public void AddTag(Tag tag, TagInfo tagInfo)
        {
            tags.Add(tagInfo.TagId, tag);

            Thread t = new Thread(new ParameterizedThreadStart(Scan));//add parametere to thread
            threads.Add(tagInfo.TagId, t);//add to collection
            //add to infos collection
            infos.Add(tagInfo.TagId, tagInfo);

            t.Start(tagInfo);//start the thread with parameter of it's scan time

           // Console.WriteLine("Tag je dodat.");
        }

        public void RemoveTag(string tagId)
        {
            //lock the tags collection to prevent deadlock
            lock (tags)
            {
                threads[tagId].Abort();
                tags.Remove(tagId);

            }
            //lock the infos collection to prevent deadlock
            lock(infos)
            {
                infos.Remove(tagId);
            }
           // Console.WriteLine("Infos removed");
        }

        public void ToggleTagAutoManual(string tagId)
        {
            throw new NotImplementedException();
        }

        private void Scan(object tagInfo)
        {
            int scanTime = ((TagInfo)tagInfo).ScanTime;

            double val;

            while (true)
            {
                switch (((TagInfo)tagInfo).FunctionType)
                {
                    case "Sine":
                        val = SimulationDriver.Sine();

                        break;
                    case "Cosine":
                        val = SimulationDriver.Cosine();

                        break;
                    default:
                        val = SimulationDriver.Ramp();

                        break;

                }
                Tag tag = new Tag(val, DateTime.Now);
                Write(((TagInfo)tagInfo).TagId, tag);
                //sleep for scan time
                Thread.Sleep(scanTime);

            }
        }
         
         //destructor
         ~ScadaModel()
        {
            //save ScadaModel to database.txt
            XmlSerializer serializer = new XmlSerializer(typeof(ScadaModel));

            using (TextWriter textWriter = new StreamWriter("database.xml"))
            {

                serializer.Serialize(textWriter, this);

            }
         
        }

    }

    

   
}
