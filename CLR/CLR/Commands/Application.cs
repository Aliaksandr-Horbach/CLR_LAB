using System;
using System.Collections.Generic;
using TraceResultFormatter;

namespace CLR.Commands
{
    public class Application
    {
       
        public void RunCommand(string command)
        {
            var tracefoFormatter = new TraceResultFormatter.TraceResultFormatter();

            var runTests=new RunTests();
            var testResults= runTests.Run();

            var writeInfo=new WriteCommand();

            var extansion = "";
            var path = "";

            switch (command)
            {
                case "--f":
                    {

                        Console.WriteLine("Choose format of result: \n" + "Console\nXml");
                        
                        var formattersFactory=new FormatterFactory();
                        var names=formattersFactory.GetFormatorsNames();

                        foreach (var name in names)
                        {
                            Console.WriteLine(name);
                        }

                        extansion = Console.ReadLine();

                        if (extansion != null && extansion.Equals("console"))
                        {
                            var d = new XmlSerializer.XmlSerializer();
                            Console.WriteLine(d.SerializeInformation(testResults));
                        }
                        Console.WriteLine("Choose path to file (including name):");
                        path = Console.ReadLine();
                        writeInfo.Write(extansion,testResults,path);

                        break;
                    }
                case "--o":
                    {
                      
                        break;
                    }
                case "--w":
                    {
                        
                        break;
                    }
                case "--h":
                    {
                        Console.WriteLine("Avalible Extensions:\nConsole\nXml");
                        tracefoFormatter.GetFormatorsTypes();
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
                default:  Console.WriteLine("Wrong command.");   break;
            }
        }
    }

}
