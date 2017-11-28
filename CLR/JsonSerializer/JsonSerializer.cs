﻿using System;
using System.IO;
using AppLicationPlugins;


namespace JsonSerializer
{
    public class JsonSerializer:Plugins
    {
        public override void SerializeInformation(string extansion, object obj, string path)
        {
            if (path != null)
            {
                using (StreamWriter file = File.CreateText(path + "." + extansion))
                {
                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, obj);
                    Console.WriteLine("Successful writing to a file!");
                }
            }
        }
    }
}
