using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jogo_da_velha.Logica_jogo;
using Jogo_da_velha.Logica_jogo.Entidades;

namespace Jogo_da_velha.UI
{
    public static class UI
    {
        public static void ImprimirBoasVindas()
        {
            System.Console.WriteLine("Bem vindo ao jogo da velha!");
        }

        internal static void ExibirMensagemEmpate()
        {
            System.Console.WriteLine("O jogo empatou!");
        }

        internal static void ExibirMensagemJogadaInvalida()
        {
            System.Console.WriteLine("Jogada inválida... Tente novamente.");
        }

        internal static void ExibirMensagemJogadorAtual(Jogador jogadorAtual)
        {
            System.Console.WriteLine("É a vez de " + jogadorAtual.Nome);
        }

        internal static void ExibirMensagemPecaJogadores(string nomeJogador, string nomeAdversario)
        {
            System.Console.WriteLine($"{nomeJogador} é X e {nomeAdversario} é O");
        }

        internal static void ExibirMensagemVitoria(Jogador jogadorAtual)
        {
            System.Console.WriteLine("O jogador " + jogadorAtual.Nome + " venceu!");
        }

        internal static void ExibirTabuleiro(Tabuleiro tabuleiro)
        {
             var casas = tabuleiro.ObterCasas(); 

            var strBuilder = new StringBuilder(); 

            for (int i = 0; i < Tabuleiro.TAM_TABULEIRO; i++)
            {

                for (int j = 0; j < Tabuleiro.TAM_TABULEIRO; j++)
                {
                    if(casas[i,j].EstaVazia()) strBuilder.Append(" "); 
                    else strBuilder.Append(casas[i,j].Peca.ToString());

                    if(j < Tabuleiro.TAM_TABULEIRO - 1) strBuilder.Append("|");
                }
                if(i < Tabuleiro.TAM_TABULEIRO - 1) strBuilder.Append("\n-----\n");
            }
        }

        internal static string PerguntarNomeJogador(string competidor)
        {
            System.Console.WriteLine($"Qual é o nome do jogador {competidor}?");
            return Console.ReadLine();
        }

        internal static int PerguntarPosicaoJogada(List<int> posicoesDisponiveis)
        {
            System.Console.WriteLine("Escolha uma posição para jogar: ");
            System.Console.Write("Posições disponíveis: ");
            posicoesDisponiveis.ForEach(pos => System.Console.Write(pos + " "));
            System.Console.WriteLine();

            return int.Parse(Console.ReadLine());
        }
    }
}