using System;
using NUnit.Framework;
using Oracle.ManagedDataAccess.Client;

namespace InsaManagementSystem.database
{
    [TestFixture]
    public class ConnectionTest
    {
        [Test]
        public void 데이터베이스연결테스트()
        {
            var connection = new Connection("TINSA", "localhost", "1234", "1521");
            connection.getConnection().Open();
        }
        [Test]
        public void 데이터베이스연결실패()
        {
            Assert.Throws<OracleException>(() =>
            {
                var connection = new Connection("TINSA", "localhost", "WrongPassword", "1521");
                connection.getConnection().Open();
            });
        }

    }
}