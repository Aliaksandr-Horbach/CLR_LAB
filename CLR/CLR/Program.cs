using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
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
                                        var d = new WriteToFile();
                                        d.JsonWriting(expansionvalue.ToString(), infa);
                                        break;
                                    }
                            case "4":
                                    {
                                        var d = new WriteToFile();
                                        d.YamlWriting(expansionvalue.ToString(),infa);
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
                            "Help:\n --f     -Selection of output format\n --o     -Selection of output path \n --clear -Clear console");
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

    

