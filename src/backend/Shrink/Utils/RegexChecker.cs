using System.Text.RegularExpressions;

namespace Shrink
{
    public static class RegexChecker
    {
        public static bool IsUrlValid(string url)
        {
            return Regex.IsMatch(url, 
                "^(?:http(s)?:\\/\\/)?[\\w.-]+(?:\\.[\\w\\.-]+)+[\\w\\-\\._~:/?#[\\]@!\\$&'\\(\\)\\*\\+,;=.]+$");
        }
    }
}