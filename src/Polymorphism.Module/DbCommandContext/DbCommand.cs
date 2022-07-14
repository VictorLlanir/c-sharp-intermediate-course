using Polymorphism.Module.DatabaseContext;
using Polymorphism.Module.DatabaseContext.Enums;

namespace Polymorphism.Module.DbCommandContext
{
    public class DbCommand
    {
        private readonly DbConnection _connection;
        private readonly string _instruction;

        public DbCommand(DbConnection connection, string instruction)
        {
            _connection = connection ?? throw new InvalidOperationException("A DbCommand must have a valid connection.");
            _instruction = !string.IsNullOrEmpty(instruction) ? instruction : throw new InvalidOperationException("A DbCommand must have a valid instruction.");
        }

        public void Execute()
        {
            if (_connection.ConnectionState == ConnectionState.Closed) _connection.Open();
            // Run command
            _connection.Close();
        }
    }
}
