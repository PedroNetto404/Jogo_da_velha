using Jogo_da_velha.Logica_jogo;
using Jogo_da_velha.Logica_jogo.Entidades;
using Jogo_da_velha.Logica_jogo.Entidades.Pecas;
using Jogo_da_velha.UI;

UI.ImprimirBoasVindas(); 

string nomeJogador = UI.PerguntarNomeJogador("jogador");
string nomeAdversario = UI.PerguntarNomeJogador("adversário");

UI.ExibirMensagemPecaJogadores(nomeJogador, nomeAdversario); 

var jogo = new Jogo
(
    new Jogador(nomeJogador, new Cruzado()),
    new Jogador(nomeAdversario, new Bolinha())
); 

jogo.Iniciar();

while(jogo.EmExecucao)
{
    UI.ExibirTabuleiro(jogo.Tabuleiro);
    UI.ExibirMensagemJogadorAtual(jogo.JogadorAtual);

    var posicoesIndexDisponiveis = jogo.ObterJogadasDisponiveis()
                                       .Select(p => MapeadorDePosicoes.MapearIndice(p))
                                       .ToList();

    var posicaoIndex = UI.PerguntarPosicaoJogada(posicoesIndexDisponiveis); 
    
    if(!posicoesIndexDisponiveis.Contains(posicaoIndex))
    {
        UI.ExibirMensagemJogadaInvalida(); 
        continue;
    }

    var posicao = MapeadorDePosicoes.MapearPosicao(posicaoIndex);
    jogo.RealizarJogada(posicao);

    if(jogo.OcorreuVitoria())
    {
        UI.ExibirMensagemVitoria(jogo.JogadorAtual);
        jogo.Encerrar();
    }
    else if(jogo.OcorreuEmpate())
    {
        UI.ExibirMensagemEmpate();
        jogo.Encerrar();
    }
}