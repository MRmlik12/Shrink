using Xunit;

namespace Shrink.Tests
{
    public class RegexTests
    {
        [Fact]
        public void CheckIfUrlIsCorrect()
        {
            var result = RegexChecker.IsUrlValid("https://google.com");
            Assert.True(result);
        }
    }
}