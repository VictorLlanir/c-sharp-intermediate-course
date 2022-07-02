using Modules.Tests.Polymorphism.Helpers;
using Polymorphism.Module.DatabaseContext.Enums;
using Polymorphism.Module.DatabaseContext.Implementations;
using System;
using Xunit;

namespace Modules.Tests.Polymorphism
{
    public class OracleConnectionTests
    {
        [Fact(DisplayName = "Should throw InvalidOperationException when trying to close a not openned connection")]
        public void CloseWithoutOpenning()
        {
            using var oracleConnection = new OracleConnection(Constants.ValidConnectionString);

            Assert.Throws<InvalidOperationException>(() => oracleConnection.Close());
        }

        [Fact(DisplayName = "Should throw InvalidOperationException when trying to open an already openned connection")]
        public void OpenningTwice()
        {
            using var oracleConnection = new OracleConnection(Constants.ValidConnectionString);

            oracleConnection.Open();

            Assert.Throws<InvalidOperationException>(() => oracleConnection.Open());
        }

        [Fact(DisplayName = "Should be successfully openned")]
        public void SuccesfullyOpenned()
        {
            using var oracleConnection = new OracleConnection(Constants.ValidConnectionString);

            oracleConnection.Open();
            var expected = ConnectionState.Open;

            Assert.Equal(expected, oracleConnection.ConnectionState);
        }

        [Fact(DisplayName = "Should be successfully closed")]
        public void SuccesfullyClosed()
        {
            using var oracleConnection = new OracleConnection(Constants.ValidConnectionString);

            oracleConnection.Open();
            oracleConnection.Close();
            var expected = ConnectionState.Closed;

            Assert.Equal(expected, oracleConnection.ConnectionState);
        }
    }
}
