﻿using System;
using System.IO;
using AppLicationPlugins;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace ParsePlugins
{
    public class ParsePlugins:IPlugins
    {


        public void JsonWrite(string extansion, object obj, string path)
        {

            if (path != null)
            {
                using (StreamWriter file = File.CreateText(path + "." + extansion))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, obj);
                    Console.WriteLine("Successful writing to a file!");
                }
            }
        }

        public void JsonOutput(object obj)
        {

            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Console.WriteLine(json);

        }

        public void YamlWrite(string extansion, object obj,string path)
        {
            
            if (path != null)
            {
                using (StreamWriter file = File.CreateText(path + "." + extansion))
                {
                    var seriazer = new Serializer();
                    seriazer.Serialize(file, obj);
                    Console.WriteLine("Successful writing to a file!");
                }
            }
        }
    }
}
