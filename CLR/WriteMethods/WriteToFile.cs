using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using TracerImplementation;
using WriteMethods.Interfaces;

namespace WriteMethods
{
    public class WriteToFile:IWriteToFile
    {
        

        [XmlInclude(typeof(WritedInformation))]
        public void WriteTests(string extansion,string tests,string path)
        {

            if (path != null)
            {
                File.WriteAllText(path+"."+extansion, tests);
                //using (StreamWriter file = File.CreateText(path + "." + extansion))
                //{
                //    var serializer = new XmlSerializer(typeof(WritedInformation));
                //    serializer.Serialize(file, obj);
                //    Console.WriteLine("Successful writing to a file!");

                //}
            }
        }


        
    }
}
