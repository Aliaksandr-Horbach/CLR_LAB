using System;
using System.IO;

namespace CLR.Commands
{
    public class ReadHelp
    {
        public void ReadFile()
        {
            try
            {
                using (var streamReader=new StreamReader("Help.txt"))
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
