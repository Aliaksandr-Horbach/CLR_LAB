using System.Collections;
using System.Collections.Generic;


namespace TracerImplementation
{
     public class WritedInformation
     {
        private List<TraceResult> list { get; }
        private double fulltime { get; }


        public WritedInformation(List<TraceResult> list, double fulltime)
        {
            this.fulltime = fulltime;
            this.list = list;
        }


     }
}
