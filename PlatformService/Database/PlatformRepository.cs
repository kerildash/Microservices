using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Database;

public class PlatformRepository(AppDbContext context) : IPlatformRepository
{
    public async Task CreateAsync(Platform platform)
    {
        if (platform is null)
        {
            throw new ArgumentNullException($"{nameof(platform)} is null ");
        }

        await context.Platforms.AddAsync(platform);
    }

    public async Task<IEnumerable<Platform>> GetAllAsync()
    {
        return await context.Platforms.ToListAsync();
    }

    public async Task<Platform?> GetByIdAsync(int id)
    {
        return await context.Platforms.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() >= 0 ? true : false;
    }
}
