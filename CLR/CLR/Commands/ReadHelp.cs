using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR.Commands
{
    public class ReadHelp
    {
        public void ReadFile()
        {
            try
            {
                using (StreamReader streamReader=new StreamReader("Help.txt"))
                {
                    String line = streamReader.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
