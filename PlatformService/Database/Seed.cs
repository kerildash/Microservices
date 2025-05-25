using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Database;
public static class Seed
{
    public static void Populate(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(
                serviceScope.ServiceProvider.GetService<AppDbContext>()
                ?? throw new ArgumentNullException("AppDbContext is null"));
        }
    }

    private static void SeedData(AppDbContext context)
    {
        Console.WriteLine("Using In-Memory Database for PlatformService");

        
        if (context.Platforms.Any())
        {
            Console.WriteLine("Data already exists in the database.");
            return; // Data already seeded
        }

        Console.WriteLine("Seeding data into the database...");

        context.Platforms.AddRange(
            new Platform { Name = "Docker", Publisher = "Docker Inc.", Cost = "Free" },
            new Platform { Name = "Redis", Publisher = "Redis Labs", Cost = "Free" },
            new Platform { Name = "RabbitMQ", Publisher = "Pivotal Software", Cost = "Free" },
            new Platform { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" },
            new Platform { Name = "AWS Lambda", Publisher = "Amazon", Cost = "Pay as you go" },
            new Platform { Name = "Google Cloud Run", Publisher = "Google", Cost = "Pay as you go" }
        );

        context.SaveChanges();
    }
}