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
        [InlineData("CATDBHFG")]   // only uppercase
        [InlineData("cat")]        // only lowercase
        [InlineData("2001")]       // only digits
        [InlineData("&&&")]        // only symbols
        public void Test_Weak(string password)
        {
            var result = _checker.CheckPasswordStrength(password);
            Assert.Equal("WEAK", result);
        }

        [Theory]
        [InlineData("Duck")]   // upper + lower
        [InlineData("C2")]     // upper + digit
        [InlineData("j9")]     // lower + digit
        [InlineData("a!")]     // lower + symbol
        [InlineData("9^")]     // digit + symbol
        [InlineData("A)")]     // upper + symbol
        public void Test_Medium_TwoCriteria(string password)
        {
            var result = _checker.CheckPasswordStrength(password);
            Assert.Equal("MEDIUM", result);
        }

        [Theory]
        [InlineData("Ab1")]   // upper + lower + digit
        [InlineData("Ab!")]   // upper + lower + symbol
        [InlineData("a1!")]   // lower + digit + symbol
        [InlineData("A1!")]   // upper + digit + symbol
        public void Test_Medium_ThreeCriteria(string password)
        {
            var result = _checker.CheckPasswordStrength(password);
            Assert.Equal("MEDIUM", result);
        }

        [Theory]
        [InlineData("Ab1!")]    // 4 criteria but too short
        [InlineData("Xy9$")]    // 4 criteria but too short
        [InlineData("aB3@")]    // 4 criteria but too short
        [InlineData("12Ad#")]   // 4 criteria but too short
        [InlineData("j9*HAa")]  // 4 criteria but too short
        public void Test_Medium_FourCriteriaButTooShort(string password)
        {
            var result = _checker.CheckPasswordStrength(password);
            Assert.Equal("MEDIUM", result);
        }

        [Theory]
        [InlineData("8hN321")]   // upper + lower + digit, length < 8 → MEDIUM
        public void Test_Medium_ThreeCriteriaShort(string password)
        {
            var result = _checker.CheckPasswordStrength(password);
            Assert.Equal("MEDIUM", result);
        }

        [Theory]
        [InlineData("Thy12@erty")]    // STRONG
        [InlineData("Plikhjufg1@T")]  // STRONG
        [InlineData("Ab1!xyzq")]      // STRONG
        [InlineData("StrongP@ss1")]   // STRONG
        [InlineData("Hello123!")]     // STRONG
        public void Test_Strong(string password)
        {
            var result = _checker.CheckPasswordStrength(password);
            Assert.Equal("STRONG", result);
        }
    }
}

