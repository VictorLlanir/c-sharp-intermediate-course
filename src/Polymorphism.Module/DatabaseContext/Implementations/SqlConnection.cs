namespace Polymorphism.Module.DatabaseContext.Implementations
{
    public class SqlConnection : DbConnection
    {
        public SqlConnection(string connectionString, TimeSpan? timeout = null) : base(connectionString, timeout) { }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void Open()
        {
            throw new NotImplementedException();
        }
    }
}
