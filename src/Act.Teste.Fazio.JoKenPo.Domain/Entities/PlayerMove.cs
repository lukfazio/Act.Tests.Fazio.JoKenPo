namespace Act.Teste.Fazio.JoKenPo.Domain.Entities;

public sealed class PlayerMove
{
    public string PlayerName { get; init; }

    public PossiblePlays PlayerChoice { get; init; }

    private PlayerMove()
    {
    }

    private PlayerMove(string playerName, PossiblePlays playerChoice) : this()
    {
        PlayerName = playerName;
        PlayerChoice = playerChoice;
    }

    public static PlayerMove Create(string playerName, PossiblePlays playerChoice)
    {
        return new PlayerMove(playerName, playerChoice);
    }
}