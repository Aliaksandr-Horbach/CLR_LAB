using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using AppLicationPlugins;
using TraceResultGetter.Interfaces;


namespace TraceResultGetter
{
    public class TraceResultGetter:ITraceResultGetter
    {

        public Dictionary<string,IPlugin> GetFormatorsTypes()
        {
            var xml = new XmlSerializer.XmlSerializer();
            var formatorsTypes = new Dictionary<string, IPlugin> {{"console", xml}, {"xml", xml}};
            var pluginsFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException(), "Plugins");
            foreach (var pluginPath in Directory.GetFiles(pluginsFolder, "*.dll", SearchOption.TopDirectoryOnly))
            {
                var newAssembly = Assembly.LoadFrom(pluginPath);
                foreach (var type in newAssembly.GetExportedTypes())
                {
                    if (type.IsClass && type.GetInterface(typeof(IPlugin).FullName) != null)
                    {
                        var ctor = type.GetConstructor(new Type[] { });
                        if (ctor != null)
                        {
                            if (ctor.Invoke(new object[] { }) is IPlugin plugin) formatorsTypes.Add(plugin.Name, plugin);
                        }
                    }
                }

            }
            return formatorsTypes;
        }

    }    
}
