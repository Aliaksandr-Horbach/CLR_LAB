using System;


namespace CLR
{
    public class WriteCommand
    {
        public void Write(string extansion, object testResults,string path)
        {
           
            switch (extansion)
            {

                case "xml":
                {
                    var d = new XmlSerializer.XmlSerializer();
                    d.SerializeInformation(testResults);
                    break;
                }

                case "json":
                {
                    try
                    {
                       
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    break;
                }
                case "yaml":
                {
                    try
                    {
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    break;
                }
                default:
                    Console.WriteLine("Invalid file extension entered.");
                    break;
            }
        }
    }
}
