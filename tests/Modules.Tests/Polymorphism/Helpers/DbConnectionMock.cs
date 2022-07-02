using Polymorphism.Module.DatabaseContext;
using Polymorphism.Module.DatabaseContext.Contracts;
using Polymorphism.Module.DatabaseContext.Enums;
using System;

namespace Modules.Tests.Polymorphism.Helpers
{
    public class DbConnectionMock : DbConnection
    {
        public DbConnectionMock(string connectionString, TimeSpan? timeout = null) : base(connectionString, timeout) { }

        public override ConnectionState ConnectionState { get; protected set; }

        public override void Close() { }
        public override IDbConnection Open() => this;
    }
}
