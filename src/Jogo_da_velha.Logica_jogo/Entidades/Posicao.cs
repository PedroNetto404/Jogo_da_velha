using Jogo_da_velha.Logica_jogo.Exceptions;

namespace Jogo_da_velha.Logica_jogo;

public class Posicao : IEquatable<Posicao>
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public Posicao(int x, int y) => (X, Y) = (x, y);

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
}
