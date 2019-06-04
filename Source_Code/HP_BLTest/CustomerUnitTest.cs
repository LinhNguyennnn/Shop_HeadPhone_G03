using System;
using Xunit;
using HP_BL;

namespace HP_BLTest
{
    public class CustomerUnitTest
    {
        Customer_BL cusBL = new Customer_BL();
        [Theory]
        [InlineData("Linh", "nal123")]
        [InlineData("Thang", "lbt456")]
        [InlineData("Dan", "nvd789")]
        public void LoginTest(string Un, string Pw)
        {
            Assert.NotNull(cusBL.Login(Un, Pw));
        }
        [Theory]
        [InlineData("", "")]
        [InlineData("@%^&#", ",,..,")]
        [InlineData("24v14v", "12412312")]
        public void LoginTest1(string Un, string Pw)
        {
            Assert.Null(cusBL.Login(Un, Pw));
        }
    }
}
