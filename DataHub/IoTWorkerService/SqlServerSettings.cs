using DbCommunicationLib;

namespace IoTWorkerService
{
    class SqlServerSettings: IDbContextSettings
    {
        public string Host { get; init; }
        public string Database { get; init; }
        public string UserName { get; init; }
        public string Password { get; init; }
    }
}
