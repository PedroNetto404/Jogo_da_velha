using Jogo_da_velha.Logica_jogo.Entidades.Pecas;

namespace Jogo_da_velha.Logica_jogo;

public class Tabuleiro
{
    public Casa[,] Casas { get; private set; }
    public const int TAM_TABULEIRO = 3;

    public Tabuleiro()
    {
        Casas = new Casa[TAM_TABULEIRO, TAM_TABULEIRO];

        for (int i = 0; i < TAM_TABULEIRO; i++)
        {
            for (int j = 0; j < TAM_TABULEIRO; j++)
            {
                Casas[i,j] = new Casa(new Posicao(i, j), null);
            }
        }
    }

    public void MoverPeca(Posicao origem, Posicao destino)
    {
        Casa casaOrigem = Casas.ObterCasa(origem);
        Casa casaDestino = Casas.ObterCasa(destino);

        casaDestino.ColocarPeca(casaOrigem.Peca);
        casaOrigem.RemoverPeca(); 
    }

    public bool CasaEstaVazia(Posicao posicao) => Casas.ObterCasa(posicao).EstaVazia();
    public bool VerificarVitoria(Peca peca) => VerificarVitoriaHorizontalEVertical(peca) || VerificarVitoriaDiagonais(peca);

    public bool VerificarEmpate()
    {
        for (int i = 0; i < TAM_TABULEIRO; i++)
        {
            for (int j = 0; j < TAM_TABULEIRO; j++)
            {
                if(Casas[i,j].EstaVazia()) return false;
            }
        }

        return true;
    }

    private bool VerificarVitoriaHorizontalEVertical(Peca peca)
    {
        int pecasIguaisNaHorizontal = 0; 
        int pecasIguauisNaVertical = 0;

        for (int i = 0; i < TAM_TABULEIRO; i++)
        {
            for (int j = 0; j < TAM_TABULEIRO; j++)
            {
                if(Casas[i,j].Equals(peca)) pecasIguaisNaHorizontal++;
                if(Casas[j,i].Equals(peca)) pecasIguauisNaVertical++;
            }
        }

        return (pecasIguaisNaHorizontal, pecasIguauisNaVertical) == (TAM_TABULEIRO, TAM_TABULEIRO);
    }

    private bool VerificarVitoriaDiagonais(Peca peca)
    {
        int pecasIguaisNaDiagonalPrincipal = 0;
        int pecasIguaisNaDiagonalSecundaria = 0;

        for (int i = 0; i < TAM_TABULEIRO; i++)
        {
            if(Casas[i,i].Equals(peca)) pecasIguaisNaDiagonalPrincipal++;
            if(Casas[i,TAM_TABULEIRO - i - 1].Equals(peca)) pecasIguaisNaDiagonalSecundaria++;
        }

        return (pecasIguaisNaDiagonalPrincipal, pecasIguaisNaDiagonalSecundaria) == (TAM_TABULEIRO, TAM_TABULEIRO);
    }
}

public static class MatrizCasasExtension{
    public static Casa ObterCasa(this Casa[,] casas, Posicao posicao) => 
        casas[posicao.X, posicao.Y];
}