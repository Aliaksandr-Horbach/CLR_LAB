using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR
{
    public class WriteCommand
    {
        public void Write(string extansion, object testResults,string path)
        {
            var tracefoFormatter = new TraceResultFormatter.TraceResultFormatter();
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
                        tracefoFormatter.GetJsonFormat(extansion, testResults, path);
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
                        tracefoFormatter.GetYamlFormat(extansion, testResults, path);
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
