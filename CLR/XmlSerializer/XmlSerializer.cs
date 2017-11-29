using System;
using System.IO;
using System.Xml.Serialization;
using AppLicationPlugins;
using TracerImplementation;

namespace XmlSerializer
{
    public class XmlSerializer:IFormator
    {
        public string Name => "xml";

        [XmlInclude(typeof(WritedInformation))]
        public  string SerializeInformation(object obj)
        {
            
                using (StringWriter textWriter = new StringWriter())
                {
                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(WritedInformation));
                    serializer.Serialize(textWriter, obj);
                    return textWriter.ToString();
                }
            
        }
    }
}
