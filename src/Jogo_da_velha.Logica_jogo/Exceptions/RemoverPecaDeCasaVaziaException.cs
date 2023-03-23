namespace Jogo_da_velha.Logica_jogo.Exceptions;

public class RemoverPecaDeCasaVaziaException : Exception
{
    public RemoverPecaDeCasaVaziaException() 
        : base("Não é possível remover uma peça de uma casa vazia.")
    {
        
    }
}
