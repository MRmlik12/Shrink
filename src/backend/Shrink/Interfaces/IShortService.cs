using Shrink.Models;

namespace Shrink.Interfaces
{
    public interface IShortService
    {
        Short Create(Short shortUrl);
        Short Get(Short shortUrl, string code);
    }
}