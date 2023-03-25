using System.Security.Cryptography;
using System.Text;
using Jogo_da_velha.Logica_jogo;
using Jogo_da_velha.Logica_jogo.Entidades;
using Jogo_da_velha.Logica_jogo.ObjetosDeValor;

namespace Jogo_da_velha.UI
{
    public static class UI
    {
        public static void Pausar(int segundos)
        {
            Thread.Sleep(segundos * 1000);
        }
        public static void ImprimirBoasVindas()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.WriteLine("Bem vindo ao jogo da velha!");
            Console.ResetColor();
        }

        internal static void ExibirMensagemEmpate()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            System.Console.WriteLine("O jogo empatou!");
            Console.ResetColor();
        }

        internal static void ExibirMensagemErro(string message)
        {
            if(string.IsNullOrEmpty(message)) return;
            
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(message);
            Console.ResetColor();
        }

        internal static void ExibirMensagemJogadaInvalida()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed; 
            System.Console.WriteLine("Jogada inválida... Tente novamente.");
            Console.ResetColor();
        }

        internal static void ExibirMensagemJogadorAtual(Jogador jogadorAtual)
        {
            System.Console.WriteLine($"É a vez de {jogadorAtual}");
        }

        internal static void ExibirMensagemPecaJogadores(string nomeJogador, string nomeAdversario)
        {
            System.Console.WriteLine($"{nomeJogador} é X e {nomeAdversario} é O");
        }

        internal static void ExibirMensagemVitoria(Jogador jogadorAtual)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine("O jogador " + jogadorAtual.Nome + " venceu!");
            Console.ResetColor();
        }

        internal static void ExibirTabuleiro(Tabuleiro tabuleiro)
        {
            System.Console.WriteLine();

            var casas = tabuleiro.ObterCasas();
            
            var strBuilder = new StringBuilder(); 

            for (int i = 0; i < Tabuleiro.TAM_TABULEIRO; i++)
            {
                for (int j = 0; j < Tabuleiro.TAM_TABULEIRO; j++)
                {
                    if(casas[i,j].EstaVazia()) 
                        strBuilder.Append($" {(int)new Posicao(i,j)} "); 
                    else 
                        strBuilder.Append($" {casas[i,j].Peca} ");

                    if(j < Tabuleiro.TAM_TABULEIRO - 1) strBuilder.Append("|");
                }
                if(i < Tabuleiro.TAM_TABULEIRO - 1) strBuilder.Append("\n----------\n");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(strBuilder.ToString());
            System.Console.WriteLine();
            Console.ResetColor();
        }

        internal static void LimparTela()
        {
            Console.Clear();
        }

        internal static string PerguntarNomeJogador(string competidor)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.WriteLine($"Qual é o nome {competidor} jogador?");
            Console.ResetColor();
            return Console.ReadLine();
        }

        internal static int PerguntarPosicaoJogada()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.WriteLine("Escolha uma posição para jogar: ");
            Console.ResetColor();
            return int.Parse(Console.ReadLine());
        }

        public static bool PerguntarNovoJogo()
        {
            var option = 0;
            Console.ForegroundColor = ConsoleColor.Magenta;

            do
            {
                try
                {
                    Console.WriteLine("Deseja jogar novamente? (1 - Sim / 2 - Não)");
                    option = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    continue;
                }
                
            } while (!(option == 1 || option == 2));
            
            Console.ResetColor();

            return option == 1; 
        }
    }
}