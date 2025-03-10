using Act.Teste.Fazio.JoKenPo.Domain.Entities;
using Act.Teste.Fazio.JoKenPo.Domain.Extensions;
using Act.Teste.Fazio.JoKenPo.Domain.Interfaces;
using Act.Teste.Fazio.JoKenPo.Domain.UseCase.ComparePlays;
using WinConsole = System.Console;

namespace Act.Teste.Fazio.JoKenPo.Presentation.Console.Services;

internal class ConsoleJoKenPoService : IBaseService
{
    private static List<PossiblePlays> _possiblePlayes;
    private static IBaseUseCase<ComparePlaysInputDto, ComparePlaysOutputDto> _comparePlaysUseCase;

    public ConsoleJoKenPoService(List<PossiblePlays> possiblePlayes
                                , IBaseUseCase<ComparePlaysInputDto, ComparePlaysOutputDto> comparePlaysUseCase)
    {
        _possiblePlayes = possiblePlayes;
        _comparePlaysUseCase = comparePlaysUseCase;
    }

    public async Task Invoke()
    {
        var numberOfPlays = 0;
        var playsResult = new List<ComparePlaysOutputDto>();
        var player1Name = "rajesh";
        var player2Name = "sheldon";

        WinConsole.WriteLine("Iniciando o Jogo PEDRA-PAPEL-TESOURA-LAGARTO-SPOCK!");
        WinConsole.WriteLine();

        do
        {
            WinConsole.WriteLine("Insira o número de Jogadas:");
            if (!int.TryParse(System.Console.ReadLine(), out numberOfPlays))
            {
                WinConsole.WriteLine("Opção Inválida!");
            }
        } while (numberOfPlays <= 0);

        for (int i = 0; i < numberOfPlays; i++)
        {
            ComparePlaysInputDto input = null;

            do
            {
                WinConsole.WriteLine($"Insira a escolha de {player1Name} e {player2Name}:");
                var inputData = System.Console.ReadLine()?.Split(" ");
                try
                {
                    var player1Move = inputData[0].ToGameMoves();
                    var player2Move = inputData[1].ToGameMoves();

                    input = new ComparePlaysInputDto()
                    {
                        Player1 = PlayerMove.Create
                            (player1Name, _possiblePlayes.First(x => x.Move.Equals(player1Move))),
                        Player2 = PlayerMove.Create
                            (player2Name, _possiblePlayes.First(x => x.Move.Equals(player2Move)))
                    };
                }
                catch (Exception)
                {
                    WinConsole.WriteLine("Jogada inválida! Tente novamente.");
                }
            } while (input == null);

            playsResult.Add(_comparePlaysUseCase.TryToExecute(input).Result);
        }

        WinConsole.WriteLine("");
        WinConsole.WriteLine("Resultado:");

        foreach (var play in playsResult)
        {
            if (play.IsADraw)
            {
                WinConsole.WriteLine("Empate!");
            }
            else
            {
                WinConsole.WriteLine($"{play.Winner?.PlayerName} venceu!");
            }
        }

        WinConsole.WriteLine("Fim de Jogo!");
        WinConsole.WriteLine("´´´´");
    }
}