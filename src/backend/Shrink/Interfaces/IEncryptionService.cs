using Shrink.Models;

namespace Shrink.Interfaces
{
    public interface IEncryptionService
    {
        Short EncryptUrl(Short shortUrl);
        Short DecryptUrl(Short shortUrl);
    }
}