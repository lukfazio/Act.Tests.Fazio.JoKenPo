using Act.Teste.Fazio.JoKenPo.Domain.Entities;

namespace Act.Teste.Fazio.JoKenPo.Domain.UseCase.ComparePlays;

public sealed record ComparePlaysInputDto
{
    public PlayerMove Player1 { get; init; }
    public PlayerMove Player2 { get; init; }
}