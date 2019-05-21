using System;
using Xunit;
using HP_DAL;
using HP_Persistence;

namespace HP_DALTest
{
    public class UnitTest1
    {
        Customer_DAL CusDAL = new Customer_DAL();
        [Theory]
        [InlineData("nal", "nal123")]
        [InlineData("lbt", "lbt456")]
        [InlineData("nvd", "nvd789")]
        public void LoginTest1(string username, string password)
        {
            Customers Cus = CusDAL.Login(username, password);

            Assert.NotNull(Cus);
            Assert.Equal(username, password);
        }

        [Theory]
        [InlineData("customer", "123456")]
        [InlineData("'?^%'", "'.:=='")]
        [InlineData("'?^%'",null)]
        [InlineData(null, "'.:=='")]
        public void LoginTest2(string username, string password)
        {
            Assert.Null(CusDAL.Login(username, password));
        }
    }
}
