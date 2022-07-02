namespace Polymorphism.Module.DatabaseContext
{
    public abstract class DbConnection
    {
        public DbConnection(string connectionString, TimeSpan? timeout = null)
        {
            ConnectionString = connectionString;
            Timeout = timeout ?? TimeSpan.FromSeconds(30);
        }

        public string ConnectionString { get; private set; }
        public TimeSpan Timeout { get; private set; }

        public abstract void Open();
        public abstract void Close();
    }
}
