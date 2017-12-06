using System.Collections.Generic;
using System.Text;
using AppLicationPlugins;

namespace TraceResultGetter
{
    public class PluginsFactory
    {
        private static readonly TraceResultGetter TraceResult = new TraceResultGetter();
        private readonly Dictionary<string,IPlugin> _types = TraceResult.GetFormatorsTypes();

        public StringBuilder GetPluginResult(object obj, string extenson)
        {
           
            var result= new StringBuilder();
            foreach (var type in _types)
            {
                if (type.Key.ToUpper().Equals(extenson.ToUpper()))
                {
                     result.Append(type.Value.SerializeInformation(obj));
                }
                
            }

            return result;
        }

        public List<string> GetPluginssNames()
        {
            var nameList = new List<string>();
            foreach (var name in _types)
            {
                nameList.Add(name.Key);
            }
           
            return nameList;
        }

    }


}
