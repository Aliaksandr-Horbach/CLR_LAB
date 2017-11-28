using System.Collections.Generic;
using AppLicationPlugins;

namespace TraceResultFormatter.Interfaces
{
    internal interface ITraceResultFormatter
    {
        List<IFormator> GetFormatorsTypes();
    }
}
