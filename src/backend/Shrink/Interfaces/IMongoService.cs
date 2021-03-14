using Shrink.Models;

namespace Shrink.Interfaces
{
    public interface IMongoService
    {
        void Create(Short shortUrl);
        Short GetByUrl(string url);
        Short GetByCode(string code);
    }
}