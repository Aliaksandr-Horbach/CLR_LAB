using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AppLicationPlugins;
using TraceResultFormatter.Interfaces;

namespace TraceResultFormatter
{
    public class TraceResultFormatter:ITraceResultFormatter
    {

        public void GetFormatorsTypes()
        {
            List<IFormator> formatorsTypes=new List<IFormator>();
            var pluginsFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException(), "Plugins");
            foreach (var pluginPath in Directory.GetFiles(pluginsFolder, "*.dll", SearchOption.TopDirectoryOnly))
            {
                var newAssembly = Assembly.LoadFrom(pluginPath);
                foreach (var type in newAssembly.GetExportedTypes())
                {
                    if (type.IsClass && type.GetInterface(typeof(IFormator).FullName) != null)
                    {
                        var ctor = type.GetConstructor(new Type[] { });
                        var plugin = ctor.Invoke(new object[] { }) as IFormator;
                        formatorsTypes.Add(plugin);
                        
                    }
                }

            }
            
        }

    }    
}
