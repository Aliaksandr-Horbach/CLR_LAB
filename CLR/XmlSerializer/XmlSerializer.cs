﻿using System;
using System.IO;
using System.Xml.Serialization;
using AppLicationFormator;
using TracerImplementation;

namespace XmlSerializer
{
    public class XmlSerializer:IFormator
    {
        [XmlInclude(typeof(WritedInformation))]
        public  string SerializeInformation(string extansion, object obj)
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
