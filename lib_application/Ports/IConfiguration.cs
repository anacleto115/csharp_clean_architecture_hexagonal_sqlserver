namespace lib_application.Ports
{    
    public interface IConfiguration
    {
        string? Get(string key);
    }
}