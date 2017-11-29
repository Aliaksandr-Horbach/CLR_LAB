using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TraceResultFormatter
{
    public class FormatterFactory
    {
        

        public StringBuilder GetFormaterInstance(object obj, string extenson)
        {
            var traceResult = new TraceResultFormatter();
            var types= traceResult.GetFormatorsTypes();
            StringBuilder result= new StringBuilder();
            foreach (var type in types)
            {
                if (type.ToString().ToUpper().Contains(extenson.ToUpper()))
                {
                     result.Append(type.SerializeInformation(obj));
                }
                
            }

            return result;
        }

        public List<string> GetFormatorsNames()
        {
            var traceResult =new TraceResultFormatter();
            var names = traceResult.GetFormatorsTypes();
            var nameList=new List<string>();
            foreach (var name in names)
            {
                
                nameList.Add(name.Name);
            }
            return nameList;
        }

    }


}
