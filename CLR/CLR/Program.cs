using System;
using System.Diagnostics;
using System.Xml.Serialization;
using TracerImplementation;
using WriteMethods;

namespace CLR
{

    internal class Program
    {
        
        private static void Main(string[] args)
        {
            var tracefoFormatter = new TraceResultFormatter.TraceResultFormatter();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var testMethods = new TestMethods();
            testMethods.Test1();
            testMethods.Test2();
            testMethods.Test3();

            stopwatch.Stop();
            var testsTime = stopwatch.ElapsedMilliseconds;
            var testResults = Tracer.GetInstance().GetTraceList();

            var testsInformation = new WritedInformation(testsTime, testResults);


            var extansion = "";
            var path = "";

            while (true)
            {
                Console.WriteLine("Input command:");
                var command = Console.ReadLine();

                switch (command)
                {
                    case "--f":
                    {
                        Console.WriteLine("Choose format of result \n" +"console(xml view) \nxml");
                        tracefoFormatter.GetPluginsName();
                        extansion = Console.ReadLine();
                            if( extansion != null && extansion.Equals("console"))
                            {
                                var serializer = new XmlSerializer(typeof(WritedInformation), new[] { typeof(WritedInformation) });
                                serializer.Serialize(Console.Out, testsInformation);
                            }
                        break;
                    }
                    case "--o":
                    {
                        Console.WriteLine("Choose path to file (including name):");
                        path = Console.ReadLine();
                        break;
                    }
                    case "--w":
                    {
                        switch (extansion)
                        {

                            case "xml":
                            {
                                var d = new WriteToFile();
                                d.XmlWrite(extansion, testsInformation, path);
                                break;
                            }

                            case "json":
                            {
                                try
                                {
                                    tracefoFormatter.GetJsonFormat(extansion, testsInformation, path);
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
                                    tracefoFormatter.GetYamlFormat(extansion,testsInformation,path); 
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
                        break;
                    }
                    case "--h":
                    {
                            Console.WriteLine("Avalible Extensions:\nConsole\nXml");
                            tracefoFormatter.GetPluginsName();
                            Console.WriteLine(
                            "\nHelp:\n--f      -Selection of output format\n" +
                            "--o      -Selection of output path\n" +
                            "--w      -Write information to a file\n" +
                            "--status -Current settings of path to file and extension" +
                            "\n--clean  -Clear console\n" +
                            "--exit   -Exit from console");
                        break;
                    }
                    case "--status":
                    {
                        Console.WriteLine("Current extension of file: {0}\nCurrent path path for writing:{1} ",extansion, path);
                        break;
                    }
                    case "--clean":
                    {
                        Console.Clear();   break;

                    }
                    case "--exit":
                    {
                            Environment.Exit(0); break;

                    }
                    default:
                        Console.WriteLine("Wrong command.");
                        break;
                }
            }
        }

        
    }
}