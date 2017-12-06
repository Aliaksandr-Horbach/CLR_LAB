
namespace AppLicationPlugins
{
    public interface IPlugin
    {
        string Name { get; }
        string SerializeInformation(object obj);
      
    }
}
