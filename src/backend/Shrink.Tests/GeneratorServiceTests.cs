using Microsoft.Extensions.Options;
using Moq;
using Shrink.Services;
using Xunit;

namespace Shrink.Tests
{
    public class GeneratorServiceTests
    {
        [Fact]
        public void IsCodeGeneratorReturnsValidString()
        {
            var result = new GeneratorService(null).GenerateCode();
            Assert.Equal(10, result.Length);
        }
    }
}