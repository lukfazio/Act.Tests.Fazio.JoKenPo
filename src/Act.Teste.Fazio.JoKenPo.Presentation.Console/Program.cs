using Act.Teste.Fazio.JoKenPo.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Act.Teste.Fazio.JoKenPo.Presentation.Console;

internal class Program
{
    private static async Task Main(string[] args)
    {
        IServiceCollection services = new ServiceCollection();
        var startup = new Startup();
        var serviceProvider = startup.ConfigureServices(services);

        var service = serviceProvider.GetRequiredService<IBaseService>();

        await service.Invoke();

        System.Console.ReadLine();
    }
}