using System;
using Xunit;
using HP_DAL;
using MySql.Data.MySqlClient;

namespace HP_DALTest
{
    public class DbhelperUnitTest
    {
        [Fact]
        public void OpenConnectionTest()
        {
            Assert.NotNull(DbHelper.OpenConnection());
        }
    }
}