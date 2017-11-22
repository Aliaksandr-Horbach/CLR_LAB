
namespace AppLicationPlugins
{
    public interface IPlugins
    {
        void JsonWriting(string extansion, object obj,string path);
        void YamlWriting(string extansion, object obj, string path);
    }
}
