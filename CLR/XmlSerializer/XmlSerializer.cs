using System;
using System.IO;
using System.Xml.Serialization;
using AppLicationPlugins;
using TracerImplementation;

namespace XmlSerializer
{
    public class XmlSerializer:Plugins
    {
        [XmlInclude(typeof(WritedInformation))]
        public override void SerializeInformation(string extansion, object obj, string path)
        {
            if (path != null)
            {
                using (StreamWriter file = File.CreateText(path + "." + extansion))
                {
                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(WritedInformation));
                    serializer.Serialize(file, obj);
                    Console.WriteLine("Successful writing to a file!");

                }
            }
        }
    }
}
