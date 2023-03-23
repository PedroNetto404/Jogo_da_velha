using Jogo_da_velha.Logica_jogo;

namespace Jogo_da_velha.UI;

public static class MapeadorDePosicoes
{
    private static IDictionary<int, Posicao> _posicoes = new Dictionary<int, Posicao>
    {
        {1, new Posicao(0, 0)},
        {2, new Posicao(0, 1)},
        {3, new Posicao(0, 2)},
        {4, new Posicao(1, 0)},
        {5, new Posicao(1, 1)},
        {6, new Posicao(1, 2)},
        {7, new Posicao(2, 0)},
        {8, new Posicao(2, 1)},
        {9, new Posicao(2, 2)}
    };

    public static Posicao MapearPosicao(int index) => _posicoes.First(p => p.Key == index).Value;
    public static int MapearIndice(Posicao posicao) => _posicoes.First(p => p.Value.Equals(posicao)).Key;
}
