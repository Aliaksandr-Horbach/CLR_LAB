using System;

namespace WriteMethods.Interfaces
{
    internal interface IWiteToFile
    {   
        //Writing methods
        void JsonWriting(string extansion,object obj);
        void YamlWriting(string extansion,object obj);
        void XmlWriting(string extansion,object obj);
    }
}
