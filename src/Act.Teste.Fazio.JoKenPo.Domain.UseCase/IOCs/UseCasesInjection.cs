using Act.Teste.Fazio.JoKenPo.Domain.Entities;
using Act.Teste.Fazio.JoKenPo.Domain.Enums;
using Act.Teste.Fazio.JoKenPo.Domain.Interfaces;
using Act.Teste.Fazio.JoKenPo.Domain.UseCase.ComparePlays;
using Microsoft.Extensions.DependencyInjection;

namespace Act.Teste.Fazio.JoKenPo.Domain.UseCase.IOCs;

public static class UseCasesInjection
{
    public static void RegisterUseCases(this IServiceCollection services)
    {
        services.AddScoped<IBaseUseCase<ComparePlaysInputDto, ComparePlaysOutputDto>, ComparePlaysUseCase>();
    }

    public static void RegisterPossiblePlays(this IServiceCollection services)
    {
        services.AddSingleton(new List<PossiblePlays>
        {
            PossiblePlays.Create(GameMoves.Pedra, [GameMoves.Lagarto, GameMoves.Tesoura]),
            PossiblePlays.Create(GameMoves.Papel, [GameMoves.Pedra, GameMoves.Spock]),
            PossiblePlays.Create(GameMoves.Tesoura, [GameMoves.Papel, GameMoves.Lagarto]),
            PossiblePlays.Create(GameMoves.Lagarto, [GameMoves.Spock, GameMoves.Papel]),
            PossiblePlays.Create(GameMoves.Spock, [GameMoves.Tesoura, GameMoves.Pedra]),
        });
    }
}