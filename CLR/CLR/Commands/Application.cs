using System;
using TraceResultGetter;

namespace CLR.Commands
{
    public class Application
    {
       
        public void RunCommand(string command, PluginsFactory pluginsesFactory)
        {

            var runTests=new RunTests();
            var testResults= runTests.Run();

            var writeInfo=new WriteCommand();

            var extansion = "";
            var path = "";
            

            switch (command)
            {
                case "--f":
                    {

                        Console.WriteLine("Choose format of result:");
                        var names=pluginsesFactory.GetPluginssNames();
                        foreach (var name in names)
                        {
                            Console.WriteLine("-"+name);
                        }
                        extansion = Console.ReadLine();
                        if (names.Contains(extansion))
                        {
                            
                       
                        
                            Console.WriteLine("Choose path to file (including name):");
                            path = Console.ReadLine();
                            writeInfo.Write(extansion, testResults, path);
                        
                        }
                        else
                        {
                            Console.WriteLine("Wrong extansion. Type --h to get help.");
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
                        Console.WriteLine("\nAvailable extensions:");
                        var names = pluginsesFactory.GetPluginssNames();
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
                default:  Console.WriteLine("Wrong command. Type --h to get Help");   break;
            }
        }
    }

}
