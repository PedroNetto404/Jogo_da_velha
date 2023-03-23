namespace Jogo_da_velha.Logica_jogo.Entidades.Pecas;
public class Peca
{
    public override bool Equals(object? obj)
    {
        if(obj is null) return false;
        return new ComparadorDePecas().Equals(this, obj as Peca);
    }
    
}
