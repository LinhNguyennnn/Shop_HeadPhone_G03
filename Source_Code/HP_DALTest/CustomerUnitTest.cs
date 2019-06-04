using System;
using Xunit;
using HP_DAL;
using HP_Persistence;

namespace HP_DALTest
{
    public class CustomerUnitTest
    {
        Customer_DAL CusDAL = new Customer_DAL();
        [Theory]
        [InlineData("Linh", "nal123")]
        [InlineData("Thang", "lbt456")]
        [InlineData("Dan", "nvd789")]
        public void LoginTest1(string username, string password)
        {
            Assert.NotNull(CusDAL.Login(username, password));
        }

        [Theory]
        [InlineData("customer", "123456")]
        [InlineData("dasdvasd", "wd12d12")]
        [InlineData("sdcqwdqcw",null)]
        [InlineData(null, "21312")]
        public void LoginTest2(string username, string password)
        {
            Assert.Null(CusDAL.Login(username, password));
        }
    }
}