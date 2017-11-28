using System;
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
                        FormatterFactory AS = new FormatterFactory();
                        AS.asd();
                        Console.WriteLine("Choose format of result \n" + "console(xml view) \nxml");
                        tracefoFormatter.GetFormatorsTypes();
                        extansion = Console.ReadLine();
                        if (extansion != null && extansion.Equals("console"))
                        {
                            var d = new XmlSerializer.XmlSerializer();
                            Console.WriteLine(d.SerializeInformation(testResults));
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
                        writeInfo.Write(extansion,testResults,path);
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
