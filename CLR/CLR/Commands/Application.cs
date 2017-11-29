using System;
using TraceResultFormatter;

namespace CLR.Commands
{
    public class Application
    {
       
        public void RunCommand(string command)
        {

            var runTests=new RunTests();
            var testResults= runTests.Run();

            var writeInfo=new WriteCommand();

            var extansion = "";
            var path = "";
            var formattersFactory = new FormatterFactory();

            switch (command)
            {
                case "--f":
                    {

                        Console.WriteLine("Choose format of result: \n-console\n-xml");
                        var names=formattersFactory.GetFormatorsNames();
                        foreach (var name in names)
                        {
                            Console.WriteLine("-"+name);
                        }
                        extansion = Console.ReadLine();

                        if (extansion != null && extansion.Equals("console"))
                        {
                            var d = new XmlSerializer.XmlSerializer();
                            Console.WriteLine(d.SerializeInformation(testResults));
                        }
                        else
                        {
                            Console.WriteLine("Choose path to file (including name):");
                            path = Console.ReadLine();
                            writeInfo.Write(extansion, testResults, path);
                        }
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
                        Console.WriteLine("\nAvailable extensions:\n-console\n-xml");
                        var names = formattersFactory.GetFormatorsNames();
                        foreach (var name in names)
                        {
                            Console.WriteLine("-"+name);
                        }
                        var readHelp=new ReadHelp();
                        readHelp.ReadFile();
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
