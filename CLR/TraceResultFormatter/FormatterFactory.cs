using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceResultFormatter
{
    public class FormatterFactory
    {
        

        public void GetFormaterInstance(object obj)
        {
            var traceResult = new TraceResultFormatter();
            var types= traceResult.GetFormatorsTypes();
            types[1].SerializeInformation(obj);

        }

        public List<string> GetFormatorsNames()
        {
            var traceResult =new TraceResultFormatter();
            var names = traceResult.GetFormatorsTypes();
            var nameList=new List<string>();
            foreach (var name in names)
            {
                nameList.Add(name.ToString());
            }
            return nameList;
        }

    }


}
