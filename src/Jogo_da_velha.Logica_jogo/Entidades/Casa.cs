using Jogo_da_velha.Logica_jogo.Entidades.Pecas;
using Jogo_da_velha.Logica_jogo.Exceptions;

namespace Jogo_da_velha.Logica_jogo;
public class Casa
{
    public Posicao Posicao { get; private set; }
    public Peca? Peca { get; private set; }
    public Casa(Posicao posicao, Peca peca) => 
        (Posicao, Peca) = (posicao, peca);

    public void ColocarPeca(Peca peca) => Peca = peca;
    public void RemoverPeca()
    {
        if(EstaVazia())
            throw new RemoverPecaDeCasaVaziaException();

        Peca = null;
    }

    public bool EstaVazia() => Peca is null;
}
