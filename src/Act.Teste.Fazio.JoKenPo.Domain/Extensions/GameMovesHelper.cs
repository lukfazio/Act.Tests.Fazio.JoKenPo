using Act.Teste.Fazio.JoKenPo.Domain.Enums;

namespace Act.Teste.Fazio.JoKenPo.Domain.Extensions;

public static class GameMovesHelper
{
    public static GameMoves ToGameMoves(this string gameMoves)
    {
        if (gameMoves.Equals("Pedra", StringComparison.InvariantCultureIgnoreCase))
        {
            return GameMoves.Pedra;
        }

        if (gameMoves.Equals("Papel", StringComparison.InvariantCultureIgnoreCase))
        {
            return GameMoves.Papel;
        }

        if (gameMoves.Equals("Tesoura", StringComparison.InvariantCultureIgnoreCase))
        {
            return GameMoves.Tesoura;
        }

        if (gameMoves.Equals("Lagarto", StringComparison.InvariantCultureIgnoreCase))
        {
            return GameMoves.Lagarto;
        }

        if (gameMoves.Equals("Spock", StringComparison.InvariantCultureIgnoreCase))
        {
            return GameMoves.Spock;
        }

        throw new ArgumentException("Invalid Game Move");
    }
}