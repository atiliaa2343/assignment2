using Xunit;
using PasswordStrengthLib;

namespace PasswordStrengthTests
{
    public class PasswordCheckTests
    {
        private readonly PasswordCheck _checker = new PasswordCheck();

        [Fact]
        public void Test_Ineligible()
        {
            var result = _checker.CheckPasswordStrength("");
            Assert.Equal("INELIGIBLE", result);
        }

        [Theory]
        [InlineData("CATDBHFG")]   
        [InlineData("cat")]   
        [InlineData("2001")]   
        [InlineData("&&&")]   
        public void Test_Weak(string password)
        {
            var result = _checker.CheckPasswordStrength(password);
            Assert.Equal("WEAK", result);
        }

        [Theory]
        [InlineData("Duck")]   
        [InlineData("C2")]    
        [InlineData("j9")]   
        [InlineData("a!")]    
        [InlineData("9^")]    
        [InlineData("A)")]    
        public void Test_Medium_TwoCriteria(string password)
        {
            var result = _checker.CheckPasswordStrength(password);
            Assert.Equal("MEDIUM", result);
        }

        [Theory]
        [InlineData("Ab1")]   
        [InlineData("Ab!")]   
        [InlineData("a1!")]   
        [InlineData("A1!")]   
        public void Test_Medium_ThreeCriteria(string password)
        {
            var result = _checker.CheckPasswordStrength(password);
            Assert.Equal("MEDIUM", result);
        }

        [Fact]
        public void Test_Strong()
        {
            var result = _checker.CheckPasswordStrength("Ab1!");
            Assert.Equal("STRONG", result);
        }
    }
}

