using Newtonsoft.Json;
using System;
using System.Diagnostics;
using TracerImplementation;
using WriteMethods;



namespace CLR
{

    class Program
    {
        
        
        static void Main(string[] args)
        {

          
            Stopwatch stopwatch =new Stopwatch();
            stopwatch.Start();

            TestMethods testMethods=new TestMethods();
            testMethods.Test1();
            testMethods.Test2();

            stopwatch.Stop();

            var obResult = TracerImplementation.Tracer.GetInstance().GetTraceList();

            var infa=new WritedInformation(obResult, stopwatch.ElapsedMilliseconds);


            while (true)
            {
                Console.WriteLine("Input command:");
                string[] commandStrings = { "--f", "--o", "--h" };
                string command = Console.ReadLine();

                switch (command)
                {
                    case "--f":
                    {
                        Console.WriteLine("Choose format of result \n1-console(json view) \n2-xml \n3-json \n4-yaml");
                        string expansion = Console.ReadLine();
                        if (expansion.Equals("1"))
                        {
                                
                            string json = JsonConvert.SerializeObject(infa, Formatting.Indented);
                                    Console.WriteLine(json);
                            }
                        else
                        {
                                Console.WriteLine("Now select path including name of file:");
                                string path = Console.ReadLine();

                                if (path != null)
                                {
                                    //open file stream
                                    var d = new WriteToFile();
                                    d.YamlWriting(path, obResult);
                                }
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
                            "Help:\n --f -Selection of output format\n --o -Selection of output path");
                        break;
                    }
                    case "--w":
                    {
                        Console.WriteLine("Succesly writed to file");
                        break;
                    }
                     default: Console.WriteLine("Wrong command."); break;

                }
            }
            
             
        }
            
            
        }


    }

    

