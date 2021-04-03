namespace DbCommunicationLib
{
    public interface IDbContextSettings
    {
        string Host { get; }
        string Database { get; }
        string UserName { get; }
        string Password { get; }
    }
}
