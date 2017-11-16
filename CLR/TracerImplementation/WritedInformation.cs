using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;


namespace TracerImplementation
{
    [XmlInclude(typeof(WritedInformation))]
    public class WritedInformation
     {
        public List<TraceResult> list { get; }
         public double fulltime { get; }


        public WritedInformation(List<TraceResult> list, double fulltime)
        {
            this.fulltime = fulltime;
            this.list = list;
        }


     }
}
