using Polymorphism.Module.DatabaseContext.Contracts;
using Polymorphism.Module.DatabaseContext.Enums;

namespace Polymorphism.Module.DatabaseContext
{
    public abstract class DbConnection : IDisposable, IDbConnection
    {
        public abstract ConnectionState ConnectionState { get; set; }

        public DbConnection(string connectionString, TimeSpan? timeout = null)
        {
            if (string.IsNullOrEmpty(connectionString) || string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("An instance of a DbConnection cannot be created without a valid ConnectionString.");
            }

            ConnectionString = connectionString;
            Timeout = timeout ?? TimeSpan.FromSeconds(30);
            ConnectionState = ConnectionState.Closed;
        }

        public string ConnectionString { get; private set; }
        public TimeSpan Timeout { get; private set; }

        public abstract IDbConnection Open();
        public abstract void Close();

        public void Dispose()
        {
            if (ConnectionState == ConnectionState.Open)
            {
                Close();
            }
        }
    }
}
