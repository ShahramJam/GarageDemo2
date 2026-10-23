using GarageDemo2;
using Microsoft.Extensions.DependencyInjection;

namespace Garage1App;

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





