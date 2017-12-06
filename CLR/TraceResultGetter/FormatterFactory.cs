using System.Collections.Generic;
using System.Text;


// ReSharper disable once CheckNamespace
namespace TracerResultGetter
{
    public class FormatterFactory
    {
        

        public StringBuilder GetFormaterInstance(object obj, string extenson)
        {
            var traceResult = new TraceResultGetter();
            var types= traceResult.GetFormatorsTypes();
            StringBuilder result= new StringBuilder();
            foreach (var type in types)
            {
                if (type.Name.ToUpper().Equals(extenson.ToUpper()))
                {
                     result.Append(type.SerializeInformation(obj));
                }
                
            }

            return result;
        }

        public List<string> GetFormatorsNames()
        {
            var traceResult =new TraceResultGetter();
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
