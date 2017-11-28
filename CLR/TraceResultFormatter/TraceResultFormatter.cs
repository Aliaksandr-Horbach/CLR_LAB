using System;
using System.IO;
using System.Reflection;
using AppLicationFormator;

namespace TraceResultFormatter
{
    public class TraceResultFormatter
    {
       
            public void GetAllTypesName()
            {
                var pluginsFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException(), "Plugins");
                foreach (var pluginPath in Directory.GetFiles(pluginsFolder, "*.dll", SearchOption.TopDirectoryOnly))
                {
                    var newAssembly = Assembly.LoadFrom(pluginPath);
                    //foreach (var type in newAssembly.GetExportedTypes())
                    //{
                    //    Console.WriteLine(type.Name);
                    //}
                   
                }
            }

            public void GetJsonFormat(string expansionvalue, object testsInformation, string path)
            {
                var pluginsFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException(), "Plugins");
                foreach (var pluginPath in Directory.GetFiles(pluginsFolder, "JsonSerializer*.dll", SearchOption.TopDirectoryOnly))
                {
                    var newAssembly = Assembly.LoadFrom(pluginPath);

                    foreach (var type in newAssembly.GetExportedTypes())
                        if (type.IsClass && type.GetInterface(typeof(IFormator).FullName) != null)
                        {
                            var ctor = type.GetConstructor(new Type[] { });
                            if (ctor.Invoke(new object[] { }) is IFormator plugin)
                                plugin.SerializeInformation(testsInformation);
                        }
                }
            }

        

            public void GetYamlFormat(string expansionvalue, object testsInformation, string path)
            {
                var pluginsFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException(), "Plugins");
                foreach (var pluginPath in Directory.GetFiles(pluginsFolder, "YamlSerializer*.dll", SearchOption.TopDirectoryOnly))
                {
                    var newAssembly = Assembly.LoadFrom(pluginPath);
                    foreach (var type in newAssembly.GetExportedTypes())
                        if (type.IsClass && type.GetInterface(typeof(IFormator).FullName) != null)
                        {
                            var ctor = type.GetConstructor(new Type[] { });
                            if (ctor.Invoke(new object[] { }) is IFormator plugin)
                                plugin.SerializeInformation(testsInformation);
                        }
                }
            }
        }
}
