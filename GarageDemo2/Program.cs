using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GarageDemo2;

public static class Program
{
    private static void Main()
    {
        var services = new ServiceCollection();

        services.AddLogging(logging =>
        {
            logging.AddConsole();
        });

        services.AddSingleton<IRepository, FileRepository>();
        services.AddSingleton<IGarageService, GarageService>();
        services.AddSingleton<IAppManager, AppManager>();

        using ServiceProvider provider = services.BuildServiceProvider();
        provider.GetRequiredService<IAppManager>().Run();
    }
}





