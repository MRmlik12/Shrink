using Shrink.Models;

namespace Shrink.Interfaces
{
    public interface IGeneratorService
    {
        bool CheckIfExists(Short register);
        string GenerateCode();
    }
}