using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Yaml.Serialization;
using YamlDotNet.Serialization;
using Newtonsoft.Json;
using TracerImplementation;
using WriteMethods.Interfaces;

namespace WriteMethods
{
    public class WriteToFile : IWiteToFile
    {
        
        public void JsonWriting(string extansion,object obj)
        {
            Console.WriteLine("Select path including name of file:");
            string path = Console.ReadLine();
            if (path!=null)
            {
                using (StreamWriter file = File.CreateText(path +"."+extansion))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, obj);
                    Console.WriteLine("Successful writing to a file!");

                }
            }

        }

        [XmlInclude(typeof(WritedInformation))]
        public void XmlWriting(string extansion,object obj)
        {

            
            Console.WriteLine("Select path including name of file:");
            string path = Console.ReadLine();
            if (path != null)
            {
                using (StreamWriter file = File.CreateText(path + "." + extansion))
                {
                    var serializer = new XmlSerializer(typeof(WritedInformation), new Type[] { typeof(WritedInformation) });
                    serializer.Serialize(file, obj);
                    Console.WriteLine("Successful writing to a file!");

                }
            }
        }

        public void YamlWriting(string extansion,object obj)
        {
            Console.WriteLine("Select path including name of file:");
            string path = Console.ReadLine();
            if (path != null)
            {
                using (StreamWriter file = File.CreateText(path + "." + extansion))
                {
                    //YamlSerializer serializer = new YamlSerializer();
                    //serializer.Serialize(Console.Out, obj);

                    //serialization using the library Yaml.Serialization 
                    var seriazer = new Serializer();
                    seriazer.Serialize(file, obj);
                    Console.WriteLine("Successful writing to a file!");
                }
            }
        }
    }
}
