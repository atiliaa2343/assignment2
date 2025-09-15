using Xunit;
using PasswordStrengthLib;

namespace PasswordStrengthTests
{
    public class PasswordCheckTests
    {
        private readonly PasswordCheck _checker = new PasswordCheck();

        [Fact]
        public void GenerateUuidV4_ReturnsValidV4Uuid()
        {
            var uuid = _checker.GenerateUuidV4();
            // Check not null or empty
            Assert.False(string.IsNullOrEmpty(uuid));
            // Check format: 8-4-4-4-12 hex digits
            var parts = uuid.Split('-');
            Assert.Equal(5, parts.Length);
            Assert.Equal(8, parts[0].Length);
            Assert.Equal(4, parts[1].Length);
            Assert.Equal(4, parts[2].Length);
            Assert.Equal(4, parts[3].Length);
            Assert.Equal(12, parts[4].Length);
            // Check version 4 (first char of third part is '4')
            Assert.Equal('4', parts[2][0]);
            // Check variant (first char of fourth part is 8, 9, a, or b)
            char variant = char.ToLower(parts[3][0]);
            Assert.Contains(variant, new[] {'8', '9', 'a', 'b'});
        }

        [Fact]
        public void GenerateUuidV4_ReturnsUniqueUuids()
        {
            var uuid1 = _checker.GenerateUuidV4();
            var uuid2 = _checker.GenerateUuidV4();
            Assert.NotEqual(uuid1, uuid2);
        }

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

