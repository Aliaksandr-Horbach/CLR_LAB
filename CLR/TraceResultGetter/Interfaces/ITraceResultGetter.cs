using System.Collections.Generic;
using AppLicationPlugins;

namespace TraceResultGetter.Interfaces
{
    internal interface ITraceResultGetter
    {
        Dictionary<string, IPlugin> GetFormatorsTypes();
    }
}
