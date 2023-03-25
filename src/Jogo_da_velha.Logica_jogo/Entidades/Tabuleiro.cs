using Jogo_da_velha.Logica_jogo.Entidades.Pecas;
using Jogo_da_velha.Logica_jogo.Exceptions;
using Jogo_da_velha.Logica_jogo.ObjetosDeValor;

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

    public void ColocarPeca(Posicao destino, Peca peca)
    {
        Casa casaDestino = Casas.ObterCasa(destino);

        if(!casaDestino.EstaVazia())
            throw new CasaOcupadaException();
            
        casaDestino.ColocarPeca(peca);
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
        (int pecasIguaisNaHorizontal,int pecasIguauisNaVertical)  = (0,0);


        for (int i = 0; i < TAM_TABULEIRO; i++)
        {
            for (int j = 0; j < TAM_TABULEIRO; j++)
            {
                pecasIguaisNaHorizontal += Casas[i, j].TemPecaIgualA(peca) ? 1 : 0;
                pecasIguauisNaVertical += Casas[j, i].TemPecaIgualA(peca) ? 1 : 0;
            }

            if (pecasIguaisNaHorizontal == TAM_TABULEIRO || pecasIguauisNaVertical == TAM_TABULEIRO) return true;
            
            (pecasIguaisNaHorizontal, pecasIguauisNaVertical)  = (0,0);
        }

        return false;
    }

    private bool VerificarVitoriaDiagonais(Peca peca)
    {
        int pecasIguaisNaDiagonalPrincipal = 0;
        int pecasIguaisNaDiagonalSecundaria = 0;

        for (int i = 0; i < TAM_TABULEIRO; i++)
        {
            if(Casas[i,i].TemPecaIgualA(peca)) pecasIguaisNaDiagonalPrincipal++;
            if(Casas[i,TAM_TABULEIRO - i - 1].TemPecaIgualA(peca)) pecasIguaisNaDiagonalSecundaria++;
        }

        return pecasIguaisNaDiagonalPrincipal == TAM_TABULEIRO || pecasIguaisNaDiagonalSecundaria == TAM_TABULEIRO;
    }

    public Casa[,] ObterCasas()
    {
        return Casas.Clone() as Casa[,];
    }

    internal List<Posicao> ObterPosicoesVazias()
    {
        return Casas.Cast<Casa>()
                    .Where(casa => casa.EstaVazia())
                    .Select(casa => casa.Posicao)
                    .ToList();
    }
}

public static class MatrizCasasExtension{
    public static Casa ObterCasa(this Casa[,] casas, Posicao posicao) => 
        casas[posicao.X, posicao.Y];
}
