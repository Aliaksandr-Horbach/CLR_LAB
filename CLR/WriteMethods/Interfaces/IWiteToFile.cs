namespace WriteMethods.Interfaces
{
    interface IWiteToFile
    {   
        //Writing methods
        void JSonWriting(string path,object obj);
        void YamlWriting(string path,object obj);
        void XmlWriting(string path,object obj);
    }
}
