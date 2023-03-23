using System.IO.Compression;

namespace Jogo_da_velha.Logica_jogo.Entidades.Pecas;
public class ComparadorDePecas : IEqualityComparer<Peca>
{
    public bool Equals(Peca? x, Peca? y)
    {
        if(x is null && y is null) return true;
        if(x is null || y is null) return false;
        return x.GetType() == y.GetType();
    }
    public int GetHashCode(Peca obj)
    {
        throw new NotImplementedException();
    }
}