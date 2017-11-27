using System;
using System.IO;
using System.Reflection;
using AppLicationPlugins;
using CLR.Interfaces;

namespace CLR
{
    public class TraceResultFormatter : ITraceResultFormatter
    {
        public void GetFormat()
        {
            var pluginsFolder =
                Path.Combine(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ??
                    throw new InvalidOperationException(), "Plugins");
            foreach (var pluginPath in Directory.GetFiles(pluginsFolder, "*.dll",
                SearchOption.TopDirectoryOnly))
            {
                var newAssembly = Assembly.LoadFrom(pluginPath);


                foreach (var type in newAssembly.GetExportedTypes()) { 
                    if (type.IsClass && type.GetInterface(typeof(IPlugins).FullName) != null)
                    {
                        Console.WriteLine(type.FullName);
                    }
                }
            }
        }
    }
}
