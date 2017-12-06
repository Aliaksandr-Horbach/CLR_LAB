using System;
using TraceResultGetter;

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
                        var formaterFactory = new PluginsFactory();
                        writer.WriteTests(extansion,formaterFactory.GetPluginResult(testResults,extansion).ToString(),path);

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
                        var formaterFactory = new PluginsFactory();
                        writer.WriteTests(extansion, formaterFactory.GetPluginResult(testResults, extansion).ToString(), path);
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
