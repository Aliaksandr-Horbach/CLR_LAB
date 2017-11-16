using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Yaml.Serialization;
using YamlDotNet.Serialization;
using Newtonsoft.Json;
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
                }
            }

        }

        [XmlInclude(type: typeof(object[]))]
        public void XmlWriting(string extansion,object obj)
        {
            Console.WriteLine("Select path including name of file:");
            string path = Console.ReadLine();
            if (path != null)
            {
                using (StreamWriter file = File.CreateText(path + "." + extansion))
                {
                    var serializer = new Serializer();
                    serializer.Serialize(Console.Out, obj);

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
                    seriazer.Serialize(Console.Out, obj);
                }
            }
        }
    }
}
