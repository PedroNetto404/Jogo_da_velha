using System.Globalization;
using Jogo_da_velha.Logica_jogo;
namespace Jogo_da_velha.UI;

public class ConsoleGame
{
    private Jogo _jogo;

    public bool Rodando { get; private set; } = true;
    public ConsoleGame()
    {
        _jogo = new Jogo(); 
    }

    public void Inicializar()
    {
        _jogo.Iniciar();

        UI.ImprimirBoasVindas(); 

        string nomeJogador = UI.PerguntarNomeJogador("primeiro");
        string nomeAdversario = UI.PerguntarNomeJogador("segundo");
        _jogo.ConfigurarJogadores(nomeJogador, nomeAdversario);
        
        UI.ExibirMensagemPecaJogadores(_jogo.Jogador.Nome, _jogo.Adversario.Nome); 
        UI.Pausar(1);
    }

    public void Rodar()
    {
        string errorMessage = "";
        int jogadasInvalidasJogadorAtual = 0;
        
        while(true)
        {
            try
            {
                UI.LimparTela();
                UI.ExibirMensagemErro(errorMessage);

                if (jogadasInvalidasJogadorAtual > 0)
                {
                    UI.ExibirMensagemJogadaInvalida();
                }
                
                UI.ExibirTabuleiro(_jogo.Tabuleiro);
                
                if (!_jogo.Rodando)
                {
                    FimDeJogo();
                    break;
                }
                
                UI.ExibirMensagemJogadorAtual(_jogo.JogadorAtual);

                if (!TentarExecutarJogada())
                {
                    jogadasInvalidasJogadorAtual++;
                    continue;
                }
                
                jogadasInvalidasJogadorAtual = 0;
                
                if(!_jogo.Rodando) continue;
                
                _jogo.TrocarTurno();
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                jogadasInvalidasJogadorAtual++;
                UI.Pausar(1);
            }
            
        }

        Rodando = false;
    }

    private bool TentarExecutarJogada()
    {
        var posicaoIndex = UI.PerguntarPosicaoJogada();

        if (!_jogo.PossicaoDisponivel(posicaoIndex))
            return false;
        
        _jogo.RealizarJogada(posicaoIndex);
        return true;
    }
    private void FimDeJogo()
    {
        if (_jogo.OcorreuVitoria())
        {
            UI.ExibirMensagemVitoria(_jogo.JogadorAtual);
            _jogo.Encerrar();
        }
        else if (_jogo.OcorreuEmpate())
        {
            UI.ExibirMensagemEmpate();
            _jogo.Encerrar();
        }
    }
}