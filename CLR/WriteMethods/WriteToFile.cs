using System.IO;
using System.Xml.Serialization;
using System.Yaml.Serialization;
using Newtonsoft.Json;
using WriteMethods.Interfaces;

namespace WriteMethods
{
    public class WriteToFile : IWiteToFile
    {
        public void JSonWriting(string path, object obj)
        {
            using (StreamWriter file = File.CreateText(path))
                {
                   JsonSerializer serializer = new JsonSerializer();

                   serializer.Serialize(file, obj);
                }
        }

        public void XmlWriting(string path, object obj)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(object));
                serializer.Serialize(file, obj);
            }
        }

        public void YamlWriting(string path, object obj)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                var serializer = new YamlSerializer();
                serializer.Serialize(file, obj);
            }
        }
    }
}
