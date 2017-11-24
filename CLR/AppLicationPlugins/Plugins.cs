
namespace AppLicationPlugins
{
    abstract class Plugins:IPlugins
    {
        
        public abstract void JsonWriting(string extansion, object obj, string path);

        public abstract void YamlWriting(string extansion, object obj, string path);

        public abstract void JsonOutPut(object obj);
    }
}
