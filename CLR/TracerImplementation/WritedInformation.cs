using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Serialization;


namespace TracerImplementation
{
    [XmlRoot("WritedInformation")]
    [Serializable]
    public class WritedInformation
    {
        [XmlElement("FullTime")]
        [DefaultValue(0)]
        public double Fulltime { get; set; }
        [XmlArray("ListOfResult")]
        [XmlArrayItem("Test")]
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
