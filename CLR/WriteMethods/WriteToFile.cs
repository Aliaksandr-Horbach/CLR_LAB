using System.IO;
using System.Xml.Serialization;
using TracerImplementation;
using WriteMethods.Interfaces;

namespace WriteMethods
{
    public class WriteToFile:IWriteToFile
    {
        

        [XmlInclude(typeof(WritedInformation))]
        public void WriteInformation(string extansion,string obj,string path)
        {

            if (path != null)
            {
                using (StreamWriter file = File.CreateText(path + "." + extansion))
                {
                    file.WriteLine("fasdfaf");
                }
            }
        }

       
    }
}
