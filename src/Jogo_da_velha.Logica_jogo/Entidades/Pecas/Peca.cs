namespace Jogo_da_velha.Logica_jogo.Entidades.Pecas;
public abstract class Peca
{
    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        
        return new ComparadorDePecas().Equals(this, obj as Peca);
    }

    public static bool operator ==(Peca left, Peca right) => left.Equals(right);

    public static bool operator !=(Peca left, Peca right) => !(left == right);
}
