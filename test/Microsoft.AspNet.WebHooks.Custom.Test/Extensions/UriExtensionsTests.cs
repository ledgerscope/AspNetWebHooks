using System;
using Xunit;

namespace Microsoft.AspNet.WebHooks.Extensions
{
    public class UriExtensionsTests
    {
        [Fact]
        public void MatchesAnyAction_DetectsOnlyWildcard()
        {
            // Arrange
            var uri = new Uri("http://google.com?a=1&b=abc");

            // Act
            var actual = uri.ParseQueryString();

            // Assert
            Assert.Equal("1", actual[0]);
            Assert.Equal("abc", actual[1]);
        }
    }
}
