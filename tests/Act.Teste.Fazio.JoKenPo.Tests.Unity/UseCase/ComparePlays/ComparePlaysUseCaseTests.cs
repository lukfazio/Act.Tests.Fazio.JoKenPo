using Act.Teste.Fazio.JoKenPo.Domain.Entities;
using Act.Teste.Fazio.JoKenPo.Domain.Enums;
using Act.Teste.Fazio.JoKenPo.Domain.UseCase.ComparePlays;

namespace Act.Teste.Fazio.JoKenPo.Tests.Unity.UseCase.ComparePlays;

public class ComparePlaysUseCaseTests
{
    private readonly List<PossiblePlays> _possiblePlayes;

    public ComparePlaysUseCaseTests()
    {
        _possiblePlayes =
        [
            PossiblePlays.Create(GameMoves.Pedra, [GameMoves.Lagarto, GameMoves.Tesoura]),
            PossiblePlays.Create(GameMoves.Papel, [GameMoves.Pedra, GameMoves.Spock]),
            PossiblePlays.Create(GameMoves.Tesoura, [GameMoves.Papel, GameMoves.Lagarto]),
            PossiblePlays.Create(GameMoves.Lagarto, [GameMoves.Spock, GameMoves.Papel]),
            PossiblePlays.Create(GameMoves.Spock, [GameMoves.Tesoura, GameMoves.Pedra]),
        ];
    }

    [Theory]
    [InlineData(GameMoves.Pedra, GameMoves.Pedra, true, null)]
    [InlineData(GameMoves.Pedra, GameMoves.Lagarto, false, GameMoves.Pedra)]
    [InlineData(GameMoves.Pedra, GameMoves.Tesoura, false, GameMoves.Pedra)]
    [InlineData(GameMoves.Papel, GameMoves.Pedra, false, GameMoves.Papel)]
    [InlineData(GameMoves.Papel, GameMoves.Spock, false, GameMoves.Papel)]
    [InlineData(GameMoves.Tesoura, GameMoves.Papel, false, GameMoves.Tesoura)]
    [InlineData(GameMoves.Tesoura, GameMoves.Lagarto, false, GameMoves.Tesoura)]
    [InlineData(GameMoves.Lagarto, GameMoves.Spock, false, GameMoves.Lagarto)]
    [InlineData(GameMoves.Lagarto, GameMoves.Papel, false, GameMoves.Lagarto)]
    [InlineData(GameMoves.Spock, GameMoves.Tesoura, false, GameMoves.Spock)]
    [InlineData(GameMoves.Spock, GameMoves.Pedra, false, GameMoves.Spock)]
    public async Task ShouldReturnPlayerWinsAsParamsExpected(GameMoves movePlayer1
                                        , GameMoves movePlayer2
                                        , bool expctedDraw
                                        , GameMoves? expectedResult)
    {
        // Arrange
        var input = new ComparePlaysInputDto
        {
            Player1 = PlayerMove.Create
                            ("Player 1", _possiblePlayes.First(x => x.Move.Equals(movePlayer1))),
            Player2 = PlayerMove.Create
                            ("Player 2", _possiblePlayes.First(x => x.Move.Equals(movePlayer2)))
        };
        var comparePlaysUseCase = new ComparePlaysUseCase();

        // Act
        var result = await comparePlaysUseCase.TryToExecute(input);

        // Assert
        Assert.Equal(expectedResult, result.Winner?.PlayerChoice.Move);
        Assert.Equal(expctedDraw, result.IsADraw);
    }

    [Fact]
    public async Task ShouldReturnException()
    {
        // Arrange
        var input = new ComparePlaysInputDto
        {
            Player1 = PlayerMove.Create
                            ("Player 1", PossiblePlays.Create(GameMoves.Pedra, null)),
            Player2 = PlayerMove.Create
                            ("Player 2", PossiblePlays.Create(GameMoves.Pedra, null))
        };
        var comparePlaysUseCase = new ComparePlaysUseCase();

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(async () => await comparePlaysUseCase.TryToExecute(input));
    }
}