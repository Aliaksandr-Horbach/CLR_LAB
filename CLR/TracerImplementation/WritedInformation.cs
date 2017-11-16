using System.Collections.Generic;
using System.Xml.Serialization;


namespace TracerImplementation
{
   
    public class WritedInformation
     {
         
         public double Fulltime { get; }
         public List<TraceResult> ListOfResult { get; }


        public WritedInformation( double fulltime, List<TraceResult> listOfResult)
        {
            this.Fulltime = fulltime;
            this.ListOfResult = listOfResult;
        }
         public WritedInformation()
         {

         }


    }
}
