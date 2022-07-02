using Polymorphism.Module.DatabaseContext.Contracts;
using Polymorphism.Module.DatabaseContext.Enums;

namespace Polymorphism.Module.DatabaseContext.Implementations
{
    public class SqlConnection : DbConnection, ISqlConnection
    {
        public SqlConnection(string connectionString, TimeSpan? timeout = null) : base(connectionString, timeout) { }

        public override ConnectionState ConnectionState { get; protected set; }

        public override void Close()
        {
            if (ConnectionState == ConnectionState.Closed)
            {
                throw new InvalidOperationException("A Connection cannot be closed since it is not openned.");
            }

            ConnectionState = ConnectionState.Closed;
        }

        public override ISqlConnection Open()
        {
            if (ConnectionState == ConnectionState.Open)
            {
                throw new InvalidOperationException("A Connection cannot be openned since it is alerady openned.");
            }

            ConnectionState = ConnectionState.Open;
            return this;
        }
    }
}
