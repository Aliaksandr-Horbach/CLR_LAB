using System;
using System.IO;
using AppLicationPlugins;
using YamlDotNet.Serialization;

namespace YamlSerializer
{
    public class YamlSerializer: IPlugins
    {
        public void SerializeInformation(string extansion, object obj, string path)
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
