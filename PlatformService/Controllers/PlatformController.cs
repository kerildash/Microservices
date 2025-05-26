using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Database;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlatformController(
    IPlatformRepository repository,
    IMapper mapper) 
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPlatforms()
    {
        IEnumerable<Platform> platforms = await repository.GetAllAsync();
        
        return Ok(mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlatformById(int id)
    {
        Platform? platform = await repository.GetByIdAsync(id);
        if (platform is null)
        {
            return NotFound();
        }
        return Ok(mapper.Map<PlatformReadDto>(platform));
    }

    [HttpPost]
    public async Task<IActionResult> CreatePlatform([FromBody] PlatformCreateDto platformDto)
    {
        if (platformDto is null)
        {
            return BadRequest("Platform is null");
        }

        Platform platform = mapper.Map<Platform>(platformDto);
        await repository.CreateAsync(platform);

        if (await repository.SaveChangesAsync() is false)
        {
            return StatusCode(500, "An error occurred while saving the platform");
        }

        return CreatedAtAction(
            nameof(GetPlatformById),
            new { id = platform.Id },
            mapper.Map<PlatformReadDto>(platform));
    }
}