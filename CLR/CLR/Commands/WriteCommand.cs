using System;
using TraceResultFormatter;

namespace CLR.Commands
{
    public class WriteCommand
    {
       
        public void Write(string extansion, object testResults,string path)
        {
            var writer=new WriteMethods.WriteToFile();
            switch (extansion)
            {

                case "xml":
                {
                    var d = new XmlSerializer.XmlSerializer();
                    writer.WriteTests(extansion, d.SerializeInformation(testResults), path);
                    break;
                }

                case "json":
                {
                    try
                    {
                        var formaterFactory = new FormatterFactory();
                        writer.WriteTests(extansion,formaterFactory.GetFormaterInstance(testResults,extansion).ToString(),path);

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
                        var formaterFactory = new FormatterFactory();
                        writer.WriteTests(extansion, formaterFactory.GetFormaterInstance(testResults, extansion).ToString(), path);
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
