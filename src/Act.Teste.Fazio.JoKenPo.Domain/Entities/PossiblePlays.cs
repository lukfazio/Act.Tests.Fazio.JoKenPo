using Act.Teste.Fazio.JoKenPo.Domain.Enums;

namespace Act.Teste.Fazio.JoKenPo.Domain.Entities;

public sealed class PossiblePlays
{
    public GameMoves Move { get; init; }
    public IList<GameMoves> WinsFrom { get; init; }

    private PossiblePlays()
    {
        WinsFrom = [];
    }

    private PossiblePlays(GameMoves move, IList<GameMoves> winsFrom) : this()
    {
        Move = move;
        WinsFrom = winsFrom;
    }

    public static PossiblePlays Create(GameMoves move, IList<GameMoves> winsFrom)
    {
        return new PossiblePlays(move, winsFrom);
    }
}