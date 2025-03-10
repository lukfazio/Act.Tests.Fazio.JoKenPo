using Act.Teste.Fazio.JoKenPo.Domain.Interfaces;

namespace Act.Teste.Fazio.JoKenPo.Domain.UseCase.ComparePlays;

public sealed class ComparePlaysUseCase : IBaseUseCase<ComparePlaysInputDto, ComparePlaysOutputDto>
{
    public async Task<ComparePlaysOutputDto> TryToExecute(ComparePlaysInputDto input)
    {
        if (input.Player1.PlayerChoice.WinsFrom == null
            || input.Player1.PlayerChoice.WinsFrom.Count <= 0
            )
        {
            throw new ArgumentException("Player 1 missing WinsFrom!");
        }

        if (input.Player2.PlayerChoice.WinsFrom == null
            || input.Player2.PlayerChoice.WinsFrom.Count <= 0)
        {
            throw new ArgumentException("Player 2 missing WinsFrom!");
        }

        if (input.Player1.PlayerChoice.WinsFrom.Any(x => x.Equals(input.Player2.PlayerChoice.Move)))
        {
            return new ComparePlaysOutputDto { IsADraw = false, Winner = input.Player1 };
        }
        else if (input.Player2.PlayerChoice.WinsFrom.Any(x => x.Equals(input.Player1.PlayerChoice.Move)))
        {
            return new ComparePlaysOutputDto { IsADraw = false, Winner = input.Player2 };
        }
        else
        {
            return new ComparePlaysOutputDto { IsADraw = true, Winner = null };
        }
    }
}