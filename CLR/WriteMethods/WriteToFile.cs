using System;
using System.IO;
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
            if (path == null) return;
            File.WriteAllText(path+"."+extansion, tests);
            Console.WriteLine("Successful writing to a file!");
        }


        
    }
}
