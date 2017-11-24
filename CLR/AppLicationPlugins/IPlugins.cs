
namespace AppLicationPlugins
{
    public interface IPlugins
    {
       
        void JsonOutput(object obj);
        void JsonWrite(string extansion, object obj,string path);
        void YamlWrite(string extansion, object obj, string path);
    }
}
