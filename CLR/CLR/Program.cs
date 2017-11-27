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
        Xml = 2,
        Json,
        Yaml

    }

    internal class Program
    {
        private static void Main(string[] args)
        {
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


           string extansion = "";
            var path = "";

            while (true)
            {
                Console.WriteLine("Input command:");
                var command = Console.ReadLine();

                switch (command)
                {
                    case "--f":
                    {
                        Console.WriteLine("Choose format of result \n" +
                                          "1-console(json view) \n2-xml \n3-json \n4-yaml");
                        extansion = Console.ReadLine();
                        if (extansion.Equals("1"))
                        {
                            var pluginsFolder =
                                Path.Combine(
                                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ??
                                    throw new InvalidOperationException(), "Plugins");
                            foreach (var pluinPath in Directory.GetFiles(pluginsFolder, "*.dll",
                                SearchOption.TopDirectoryOnly))
                            {
                                var newAssembly = Assembly.LoadFrom(pluinPath);
                                foreach (var type in newAssembly.GetTypes())
                                    if (type.IsClass && type.GetInterface(typeof(IPlugins).FullName) != null)
                                    {
                                        var parser = Activator.CreateInstance(type) as IPlugins;
                                        parser.JsonOutput(testsInformation);
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
                        Enum.TryParse(extansion, out Extansions expansionvalue);
                        switch (extansion)
                        {
                            case "2":
                            {
                                var d = new WriteToFile();
                                d.XmlWrite(expansionvalue.ToString(), testsInformation, path);
                                break;
                            }

                            case "3":
                            {
                                try
                                {
                                    var pluginsFolder =
                                        Path.Combine(
                                            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ??
                                            throw new InvalidOperationException(), "Plugins");
                                    foreach (var pluginPath in Directory.GetFiles(pluginsFolder, "*.dll",
                                        SearchOption.TopDirectoryOnly))
                                    {
                                        var newAssembly = Assembly.LoadFrom(pluginPath);


                                        foreach (var type in newAssembly.GetExportedTypes())
                                            if (type.IsClass && type.GetInterface(typeof(IPlugins).FullName) != null)
                                            {
                                                var ctor = type.GetConstructor(new Type[] { });
                                                if (ctor.Invoke(new object[] { }) is IPlugins plugin)
                                                    plugin.JsonWrite(expansionvalue.ToString(), testsInformation, path);
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
                                var pluginsFolder =
                                    Path.Combine(
                                        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ??
                                        throw new InvalidOperationException(), "Plugins");
                                foreach (var pluginPath in Directory.GetFiles(pluginsFolder, "ParsePlugins*.dll",
                                    SearchOption.TopDirectoryOnly))
                                {
                                    var newAssembly = Assembly.LoadFrom(pluginPath);
                                    foreach (var type in newAssembly.GetExportedTypes())
                                        if (type.IsClass && type.GetInterface(typeof(IPlugins).FullName) != null)
                                        {
                                            var ctor = type.GetConstructor(new Type[] { });
                                            if (ctor.Invoke(new object[] { }) is IPlugins plugin)
                                                plugin.YamlWrite(expansionvalue.ToString(), testsInformation, path);
                                        }
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
                        Enum.TryParse(extansion, out Extansions expansionvalue);
                        Console.WriteLine("Current extension of file: {0}\nCurrent path path for writing:{1} ",
                            expansionvalue, path);
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
                    default:
                        Console.WriteLine("Wrong command.");
                        break;
                }
            }
        }
    }
}