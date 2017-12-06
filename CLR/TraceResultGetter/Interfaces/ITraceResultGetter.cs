using System.Collections.Generic;
using AppLicationPlugins;

namespace TracerResultGetter.Interfaces
{
    internal interface ITraceResultGetter
    {
        List<IFormator> GetFormatorsTypes();
    }
}
