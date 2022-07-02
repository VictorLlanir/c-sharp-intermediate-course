using Modules.Tests.Polymorphism.Helpers;
using Polymorphism.Module.DatabaseContext.Enums;
using Polymorphism.Module.DatabaseContext.Implementations;
using System;
using Xunit;

namespace Modules.Tests.Polymorphism
{
    public class SqlConnectionTests
    {
        [Fact(DisplayName = "Should throw InvalidOperationException when trying to close a not openned connection")]
        public void CloseWithoutOpenning()
        {
            using var sqlConnection = new SqlConnection(Constants.ValidConnectionString);

            Assert.Throws<InvalidOperationException>(() => sqlConnection.Close());
        }

        [Fact(DisplayName = "Should throw InvalidOperationException when trying to open an already openned connection")]
        public void OpenningTwice()
        {
            using var sqlConnection = new SqlConnection(Constants.ValidConnectionString);

            sqlConnection.Open();

            Assert.Throws<InvalidOperationException>(() => sqlConnection.Open());
        }

        [Fact(DisplayName = "Should be successfully openned")]
        public void SuccesfullyOpenned()
        {
            using var sqlConnection = new SqlConnection(Constants.ValidConnectionString);

            sqlConnection.Open();
            var expected = ConnectionState.Open;

            Assert.Equal(expected, sqlConnection.ConnectionState);
        }

        [Fact(DisplayName = "Should be successfully closed")]
        public void SuccesfullyClosed()
        {
            using var sqlConnection = new SqlConnection(Constants.ValidConnectionString);

            sqlConnection.Open();
            sqlConnection.Close();
            var expected = ConnectionState.Closed;

            Assert.Equal(expected, sqlConnection.ConnectionState);
        }
    }
}
