
namespace AppLicationPlugins
{
    internal abstract class Plugins:IPlugins
    {
        public abstract void SerializeInformation(string extansion, object obj, string path);
    }
}
