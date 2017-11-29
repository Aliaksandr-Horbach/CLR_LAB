using System;
using System.IO;
using AppLicationPlugins;
using YamlDotNet.Serialization;

namespace YamlSerializer
{
    public class YamlSerializer:IFormator
    {

        public string Name
        {
            get { return "yaml"; }

        }
        public  string SerializeInformation(object obj)
        {

           
                using (StringWriter textWriter = new StringWriter())
                {
                    var seriazer = new Serializer();
                    seriazer.Serialize(textWriter, obj);
                    return textWriter.ToString();
                }
            
        }
    }
}
