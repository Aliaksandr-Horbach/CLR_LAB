
namespace AppLicationPlugins
{
    public abstract class Plugins:IPlugins
    {
        public abstract void SerializeInformation(string extansion, object obj, string path);
    }
}
