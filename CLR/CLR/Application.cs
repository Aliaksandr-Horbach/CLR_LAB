﻿using System;
using System.Xml.Serialization;
using TracerImplementation;
using WriteMethods;

namespace CLR
{
    public class Application
    {
        public void RunCommand( string command)
        {
            var tracefoFormatter = new TraceResultFormatter.TraceResultFormatter();
            var runTests=new RunTests();
            var testResults= runTests.Run();
            var extansion = "";
            var path = "";

            switch (command)
            {
                case "--f":
                    {
                        Console.WriteLine("Choose format of result \n" + "console(xml view) \nxml");
                        tracefoFormatter.GetAllTypesName();
                        extansion = Console.ReadLine();
                        if (extansion != null && extansion.Equals("console"))
                        {
                            var d = new XmlSerializer.XmlSerializer();
                            var ds=new WriteToFile();
                            Console.WriteLine(d.SerializeInformation(extansion, testResults));
                            ds.WriteInformation("xml", d.SerializeInformation(extansion, testResults),"D:\\ADS");
                          
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
                                    var d = new XmlSerializer.XmlSerializer();
                                    d.SerializeInformation(extansion, testResults);
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
                                        tracefoFormatter.GetYamlFormat(extansion, runTests.Run(), path);
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
                        tracefoFormatter.GetAllTypesName();
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
                        Console.WriteLine("Current extension of file: {0}\nCurrent path path for writing:{1} ", extansion, path);
                        break;
                    }
                case "--clean":
                    {
                        Console.Clear(); break;

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
