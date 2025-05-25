using PlatformService.Models;

namespace PlatformService.Database;

public interface IPlatformRepository
{
    Task<IEnumerable<Platform>> GetAllAsync();
    Task<Platform?> GetByIdAsync(int id);
    Task CreateAsync(Platform platform);
    Task<bool> SaveChangesAsync();
}
