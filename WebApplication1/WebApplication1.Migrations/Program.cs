using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Migrations;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Applying migrations");
        var webHost = new WebHostBuilder()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<ConsoleStartup>()
            .Build();
        using (var context = (AppDbContext)webHost.Services.GetService(typeof(AppDbContext)))
        {
            context.Database.Migrate();
        }
        Console.WriteLine("Done");
    }
}