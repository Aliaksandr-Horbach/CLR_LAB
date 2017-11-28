using System;
using System.IO;
using AppLicationFormator;
using YamlDotNet.Serialization;

namespace YamlSerializer
{
    public class YamlSerializer:IFormator
    {
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
