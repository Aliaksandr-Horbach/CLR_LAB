using System.Collections.Generic;
using System.Linq;


namespace TraceResultFormatter
{
    public class FormatterFactory
    {
        

        public void GetFormaterInstance(object obj, string extenson)
        {
            var traceResult = new TraceResultFormatter();
            var types= traceResult.GetFormatorsTypes();
            foreach (var type in types)
            {
                if (type.ToString().ToUpper().Contains(extenson.ToUpper()))
                type.SerializeInformation(obj);
            }
            

        }

        public List<string> GetFormatorsNames(string extension)
        {
            var traceResult =new TraceResultFormatter();
            var names = traceResult.GetFormatorsTypes();
            var nameList=new List<string>();
            foreach (var name in names)
            {
                if(name.ToString().ToUpper().Contains(extension.ToUpper()))
                    nameList.Add(extension);
                
            }
            return nameList;
        }

    }


}
