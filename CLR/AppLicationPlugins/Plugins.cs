
namespace AppLicationPlugins
{
    internal abstract class Plugins:IPlugins
    {
        
        public abstract void JsonWrite(string extansion, object obj, string path);

        public abstract void YamlWrite(string extansion, object obj, string path);

        public abstract void JsonOutput(object obj);
    }
}
