using Modules.Tests.Polymorphism.Helpers;
using System;
using Xunit;

namespace Modules.Tests.Polymorphism
{
    public class DbConnectionTests
    {
        [Fact(DisplayName ="Should throw an InvalidOperationException when passing a null Connection String")]
        public void NullConnectionString()
        {
            Assert.Throws<InvalidOperationException>(() => new DbConnectionMock(Constants.NullConnectionString));
        }

        [Fact(DisplayName = "Should throw an InvalidOperationException when passing an empty Connection String")]
        public void EmptyConnectionString()
        {
            Assert.Throws<InvalidOperationException>(() => new DbConnectionMock(Constants.EmptyConnectionString));
        }

        [Fact(DisplayName = "Should throw an InvalidOperationException when passing a whitespace Connection String")]
        public void WhitespaceConnectionString()
        {
            Assert.Throws<InvalidOperationException>(() => new DbConnectionMock(Constants.WhitespaceConnectionString));
        }

        [Fact(DisplayName = "Should be succesfully instantiated when passing a valid Connection String")]
        public void ValidConnectionString()
        {
            Assert.IsAssignableFrom<DbConnectionMock>(new DbConnectionMock(Constants.ValidConnectionString));
        }
    }
}
