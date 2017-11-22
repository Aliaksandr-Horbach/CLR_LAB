using System;
using System.IO;
using System.Xml.Serialization;
using TracerImplementation;
using WriteMethods.Interfaces;

namespace WriteMethods
{
    public class WriteToFile:IWiteToFile
    {
        

        [XmlInclude(typeof(WritedInformation))]
        public void XmlWriting(string extansion,object obj,string path)
        {

            if (path != null)
            {
                using (StreamWriter file = File.CreateText(path + "." + extansion))
                {
                    var serializer = new XmlSerializer(typeof(WritedInformation), new Type[] { typeof(WritedInformation) });
                    serializer.Serialize(file, obj);
                    Console.WriteLine("Successful writing to a file!");

                }
            }
        }

       
    }
}
