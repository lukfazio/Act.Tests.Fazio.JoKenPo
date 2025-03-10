namespace Act.Teste.Fazio.JoKenPo.Domain.Interfaces;

public interface IBaseUseCase<TEntry, TExit>
{
    Task<TExit> TryToExecute(TEntry input);
}