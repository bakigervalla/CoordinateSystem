using CoordinateSystem.Interfaces;
using CoordinateSystem.Interfaces.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoordinateSystem;
public class Program
{
    public static Task Main(string[] args)
    {
        using var host = CreateHostBuilder(args).Build();

        Console.WriteLine(CalculateCoordinates(host.Services));
        return host.RunAsync();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
                   .ConfigureServices((_, services) =>
                    services.AddTransient<IConsole, ConsoleService>()
                            .AddTransient<IFileFactory, FileFactory>()
                            .AddTransient<ICoordinates, CoordinatesService>()
                            );
    }

    public static string CalculateCoordinates(IServiceProvider services)
    {
        using var serviceScope = services.CreateScope();
        var provider = serviceScope.ServiceProvider;

        var service = provider.GetRequiredService<IConsole>();

        return service.GetResults();
    }
}