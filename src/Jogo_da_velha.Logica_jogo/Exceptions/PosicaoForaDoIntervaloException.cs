namespace Jogo_da_velha.Logica_jogo.Exceptions;

public class PosicaoForaDoIntervaloException : Exception
{
    public PosicaoForaDoIntervaloException(string message) : base(message)
    {
    }
    public PosicaoForaDoIntervaloException(int x, int y)
     : base($"A posição ({x}, {y}) está fora do intervalo permitido.")
    {
        
    }
}
