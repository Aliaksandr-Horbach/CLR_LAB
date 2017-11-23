
namespace AppLicationPlugins
{
    public interface IPlugins
    {
        string PluginName { get; }
        void JsonOutPut(object obj);
        void JsonWriting(string extansion, object obj,string path);
        void YamlWriting(string extansion, object obj, string path);
    }
}
