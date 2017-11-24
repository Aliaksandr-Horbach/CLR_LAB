using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;


namespace TracerImplementation
{
    [XmlRoot("WritedInformation")]
    [Serializable]
    public class WritedInformation
    {
        [XmlElement("FullTime")]
        [DefaultValue(0)]
        public double FullTestsTime { get; set; }
        [XmlArray("ListOfResult")]
        [XmlArrayItem("Test")]
        public List<TraceResult> TraceResults { get; }  


        public WritedInformation( double fullTestsTimeime, List<TraceResult> traceResults)
        {
            FullTestsTime = fullTestsTimeime;
            TraceResults = traceResults;
        }

        public WritedInformation()
         {

         }


    }
}
