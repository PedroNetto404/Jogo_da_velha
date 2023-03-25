using Jogo_da_velha.Logica_jogo.Exceptions;

namespace Jogo_da_velha.Logica_jogo.ObjetosDeValor;

public class Posicao : IEquatable<Posicao>
{
    public int X { get; private set; }
    public int Y { get; private set; }
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
    public Posicao(int x, int y) => (X, Y) = (x, y);
    public static implicit operator int(Posicao posicao) => _posicoes.First(p => p.Value == posicao).Key;

    public static implicit operator Posicao(int index) => _posicoes.First(p => p.Key == index).Value;
    public override int GetHashCode() => HashCode.Combine(X, Y);
   
    public void Deslocar(int x, int y)
    {
        if(x < 0 || x > 3 || y < 0 || y > 3) 
            throw new PosicaoForaDoIntervaloException(x, y);

        (X, Y) = (x, y); 
    }

    public override bool Equals(object obj)
    {
        if(obj is not Posicao) return false;

        return Equals(obj as Posicao); 
    }

    public bool Equals(Posicao? other)
    {
        if (other is null)
        {
            return false;
        }
        return X == other.X && Y == other.Y;
    }

    public static bool operator ==(Posicao left, Posicao right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Posicao left, Posicao right)
    {
        return !(left == right);
    }
}
