
namespace AppLicationPlugins
{
    public interface IFormator
    {
        string Name { get; }
        string SerializeInformation(object obj);
      
    }
}
