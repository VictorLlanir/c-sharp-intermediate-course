using Modules.Tests.Polymorphism.Helpers;
using Polymorphism.Module.DatabaseContext.Enums;
using Polymorphism.Module.DatabaseContext.Implementations;
using Polymorphism.Module.DbCommandContext;
using System;
using Xunit;

namespace Modules.Tests.Polymorphism
{
    public class DbCommandTests
    {
        [Fact]
        public void Execute_WithClosedConnection_IsSucceeded()
        {
            var connection = new SqlConnection(Constants.ValidConnectionString);
            var dbCommand = new DbCommand(connection, Constants.ValidInstruction);

            dbCommand.Execute();
            var expectedConnectionState = ConnectionState.Closed;

            Assert.True(dbCommand.IsExecuted);
            Assert.Equal(expectedConnectionState, connection.ConnectionState);
        }

        [Fact]
        public void Execute_WithOpenedConnection_IsSucceeded()
        {
            var connection = new SqlConnection(Constants.ValidConnectionString);
            var dbCommand = new DbCommand(connection, Constants.ValidInstruction);

            connection.Open();
            dbCommand.Execute();
            var expectedConnectionState = ConnectionState.Closed;

            Assert.True(dbCommand.IsExecuted);
            Assert.Equal(expectedConnectionState, connection.ConnectionState);
        }

        [Fact]
        public void Execute_WithNullConnection_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new DbCommand(null, Constants.ValidInstruction));
        }

        [Fact]
        public void Execute_WithNullInstruction_ThrowsInvalidOperationException()
        {
            var connection = new SqlConnection(Constants.ValidConnectionString);

            Assert.Throws<InvalidOperationException>(() => new DbCommand(connection, Constants.NullInstruction));
        }

        [Fact]
        public void Execute_WithEmptyInstruction_ThrowsInvalidOperationException()
        {
            var connection = new SqlConnection(Constants.ValidConnectionString);

            Assert.Throws<InvalidOperationException>(() => new DbCommand(connection, Constants.EmptyInstruction));
        }
    }
}
