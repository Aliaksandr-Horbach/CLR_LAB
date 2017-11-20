using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using AppLicationPlugins;
using TracerImplementation;
using WriteMethods;



namespace CLR
{
    internal enum Extansions
    {
        xml=2,
        json,
        yaml
    }

    internal class Program
    {



        private static void Main(string[] args)
        {

          
            Stopwatch stopwatch =new Stopwatch();
            stopwatch.Start();

            TestMethods testMethods=new TestMethods();
            testMethods.Test1();
            testMethods.Test2();
            testMethods.Test3();

            stopwatch.Stop();
            var testsTime = stopwatch.ElapsedMilliseconds;
            var testResults = Tracer.GetInstance().GetTraceList();

            var infa=new WritedInformation(testsTime, testResults);




            while (true)
            {
                Console.WriteLine("Input command:");
                string[] commandStrings = { "--f", "--o", "--h" };
                string command = Console.ReadLine();

                switch (command)
                {
                    case "--f":
                    {
                        Console.WriteLine("Choose format of result \n"+"1-console(json view) \n2-xml \n3-json \n4-yaml");
                        string expansion = Console.ReadLine();
                        var parse = Enum.TryParse(expansion, out Extansions expansionvalue);
                        switch (expansion)
                        {
                                case "1":
                                    { 
                                        string json = JsonConvert.SerializeObject(infa, Formatting.Indented);
                                        Console.WriteLine(json);
                                        break;
                                    }
                            case "2":
                                    {
                                        var d = new WriteToFile();
                                        d.XmlWriting(expansionvalue.ToString(), infa);
                                        break;
                                    }

                            case "3":
                            {
                                string pluginsFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException(), "Plugins");
                                foreach (string pluginPath in Directory.GetFiles(pluginsFolder, "ParsePlugins*.dll", SearchOption.TopDirectoryOnly))
                                {
                                    Assembly newAssembly = Assembly.LoadFile(pluginPath);
                                    foreach (var type in newAssembly.GetExportedTypes())
                                    {
                                        if (type.IsClass && (type.GetInterface(typeof(IPlugins).FullName) != null))
                                        {
                                            var ctor = type.GetConstructor(new Type[] { });
                                            var plugin = ctor.Invoke(new object[] { }) as IPlugins;
                                            plugin.JsonWriting(expansionvalue.ToString(), infa);
                                        }
                                    }
                                }

                                        break;
                                    }
                            case "4":
                                    {
                                        string pluginsFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException(), "Plugins");
                                        foreach (string pluginPath in Directory.GetFiles(pluginsFolder, "ParsePlugins*.dll", SearchOption.TopDirectoryOnly))
                                        {
                                            Assembly newAssembly = Assembly.LoadFile(pluginPath);
                                            foreach (var type in newAssembly.GetExportedTypes())
                                            {
                                                if (type.IsClass && (type.GetInterface(typeof(IPlugins).FullName) != null))
                                                {
                                                    var ctor = type.GetConstructor(new Type[] { });
                                                    var plugin = ctor.Invoke(new object[] { }) as IPlugins;
                                                    plugin.YamlWriting(expansionvalue.ToString(), infa);
                                                }
                                            }
                                        }
                                        break;
                                    }
                            default: Console.WriteLine("Invalid file extension entered."); break;
                                   
                            }

                        break;

                    }
                    case "--o":
                    {
                        Console.WriteLine("Choose path to file (including name):");
                        string path = Console.ReadLine();
                        break;
                    }
                    case "--h":
                    {
                        Console.WriteLine(
                            "Help:\n--f  -Selection of output format\n" +
                            "--o  -Selection of output path" +
                            " \n--cl -Clear console\n" +
                            "--ex -Exit from console");
                        break;
                    }
                    case "--clear":
                    {
                        Console.Clear();
                        break;
                    }
                    case "--exit":
                    {
                         
                        Environment.Exit(0);
                        break;
                    }
                    default: Console.WriteLine("Wrong command."); break;

                }
            }
            
             
        }
            
            
        }


    }

    

