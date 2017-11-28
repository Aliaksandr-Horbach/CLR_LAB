namespace CLR.Interfaces
{
    internal interface ITraceResultFormatter
    {
        void GetPluginsFormat();
        void GetJsonFormat(string expansionvalue, object testsInformation, string path);
        void GetYamlFormat(string expansionvalue, object testsInformation, string path);
    }
}
