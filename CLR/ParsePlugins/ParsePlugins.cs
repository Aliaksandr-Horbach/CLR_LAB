using System;
using System.IO;
using AppLicationPlugins;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace ParsePlugins
{
    public class ParsePlugins:IPlugins
    {
        
        public void JsonWriting(string extansion, object obj)
        {
            Console.WriteLine("Select path including name of file:");
            string path = Console.ReadLine();
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

        public void YamlWriting(string extansion, object obj)
        {
            Console.WriteLine("Select path including name of file:");
            string path = Console.ReadLine();
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
