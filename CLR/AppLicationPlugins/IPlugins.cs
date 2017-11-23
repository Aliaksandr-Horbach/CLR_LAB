
namespace AppLicationPlugins
{
    public interface IPlugins
    {
        string PluginName { get; }
        void JsonWriting(string extansion, object obj,string path);
        void YamlWriting(string extansion, object obj, string path);
    }
}
