using Act.Teste.Fazio.JoKenPo.Domain.Entities;

namespace Act.Teste.Fazio.JoKenPo.Domain.UseCase.ComparePlays;

public sealed record ComparePlaysOutputDto
{
    public bool IsADraw { get; init; }
    public PlayerMove? Winner { get; init; }
}