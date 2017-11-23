using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml;
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


            string extansion="";
            string path = "";

            while (true)
            {
                Console.WriteLine("Input command:");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "--f":
                    {
                        Console.WriteLine("Choose format of result \n"+"1-console(json view) \n2-xml \n3-json \n4-yaml");
                        extansion = Console.ReadLine();
                        if (extansion.Equals("1"))
                        {
                            string pluginsFolder =Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ??throw new InvalidOperationException(), "Plugins");
                            foreach (var pluinPath in Directory.GetFiles(pluginsFolder, "*.dll", SearchOption.TopDirectoryOnly))
                            {
                                Assembly newAssembly = Assembly.LoadFile(pluinPath);
                                foreach (var type in newAssembly.GetTypes())
                                {
                                    if (type.IsClass && (type.GetInterface(typeof(IPlugins).FullName) != null))
                                    {
                                        var parser = Activator.CreateInstance(type) as IPlugins;
                                        parser.JsonOutPut(infa);
                                    }
                                    
                                }
                                    
                                   
                            }

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
                            var parse = Enum.TryParse(extansion, out Extansions expansionvalue);
                            switch (extansion)
                            {


                                case "2":
                                    {
                                        var d = new WriteToFile();
                                        d.XmlWriting(expansionvalue.ToString(), infa,path);
                                        break;
                                    }

                                case "3":
                                    {
                                        try
                                        {
                                            string pluginsFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException(), "Plugins");
                                            foreach (string pluginPath in Directory.GetFiles(pluginsFolder, "*.dll", SearchOption.TopDirectoryOnly))
                                            {
                                                Assembly newAssembly = Assembly.LoadFile(pluginPath);
                                            
                                                

                                                foreach (var type in newAssembly.GetExportedTypes())
                                                {
                                                    if (type.IsClass && (type.GetInterface(typeof(IPlugins).FullName) != null))
                                                    {
                                                        var ctor = type.GetConstructor(new Type[] { });
                                                        if (ctor.Invoke(new object[] { }) is IPlugins plugin) plugin.JsonWriting(expansionvalue.ToString(), infa, path);
                                                    }
                                                }
                                             }
                                            
                                         }
                                            
                                        
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e);
                                            throw;
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
                                                    if (plugin != null)
                                                        plugin.YamlWriting(expansionvalue.ToString(), infa,path);
                                                }
                                            }
                                        }
                                        break;
                                    }
                                default: Console.WriteLine("Invalid file extension entered."); break;

                            }
                            break;
                    }
                    case "--h":
                    {
                        Console.WriteLine(
                            "Help:\n--f      -Selection of output format\n" +
                            "--o      -Selection of output path\n" +
                            "--wr     -Write information to a file\n" +
                            "--status -Current settings of path to file and extension" +
                            "\n--clean  -Clear console\n" +
                            "--exit   -Exit from console");
                        break;
                    }
                    case "--status":
                    {
                        var parse = Enum.TryParse(extansion, out Extansions expansionvalue);
                        Console.WriteLine("Current extension of file: {0}\nCurrent path path for writing:{1} ",expansionvalue, path);
                        break;
                    }
                    case "--clean":
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

    

