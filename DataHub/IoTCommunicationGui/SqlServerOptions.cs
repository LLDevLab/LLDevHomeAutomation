using DbCommunicationLib;

namespace IoTCommunicationGui
{
    class SqlServerOptions : IDbContextSettings
    {
        public string Host { get; init; }
        public string Database { get; init; }
        public string UserName { get; init; }
        public string Password { get; init; }
    }
}
