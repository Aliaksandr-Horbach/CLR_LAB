
namespace AppLicationPlugins
{
    public interface IPlugins
    {
        void JsonWriting(string extansion, object obj);
        void YamlWriting(string extansion, object obj);
    }
}
