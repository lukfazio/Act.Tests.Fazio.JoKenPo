using Act.Teste.Fazio.JoKenPo.Domain.Interfaces;
using Act.Teste.Fazio.JoKenPo.Domain.UseCase.IOCs;
using Act.Teste.Fazio.JoKenPo.Presentation.Console.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Act.Teste.Fazio.JoKenPo.Presentation.Console;

public class Startup
{
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services.RegisterUseCases();
        services.RegisterPossiblePlays();
        services.AddScoped<IBaseService, ConsoleJoKenPoService>();
        return services.BuildServiceProvider();
    }
}