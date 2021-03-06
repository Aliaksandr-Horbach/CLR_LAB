﻿using System.IO;
using AppLicationPlugins;


namespace JsonSerializer
{
    public class JsonSerializer:IPlugin
    {
        public string Name => "json";


        public  string SerializeInformation(object obj)
        {

                using (StringWriter textWriter = new StringWriter())
                {
                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(textWriter, obj);
                    return textWriter.ToString();
                }
            
        }
    }
}
