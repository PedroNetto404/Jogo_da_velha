using Jogo_da_velha.Logica_jogo.Entidades;
using Jogo_da_velha.Logica_jogo.Entidades.Pecas;
using Jogo_da_velha.Logica_jogo.Exceptions;
using Jogo_da_velha.Logica_jogo.ObjetosDeValor;

namespace Jogo_da_velha.Logica_jogo;

public class Jogo
{
    public bool Rodando { get; private set; }
    public Jogador JogadorAtual { get; private set; }
    public Tabuleiro Tabuleiro {get; private set;} = new();
    public Jogador Jogador { get; private set; } = new(new Cruzado());
    public Jogador Adversario { get; private set; } = new(new Bolinha());

    public Jogo() => JogadorAtual = Jogador;

    public void Iniciar() => Rodando = true;
    public void Encerrar() => Rodando = false;

    public void RealizarJogada(Posicao jogada)
    {
        if(!Rodando)     
            throw new JogoNaoIniciadoException();

        if(!PossicaoDisponivel(jogada)) 
            throw new PosicaoIndisponivelException();

        Tabuleiro.ColocarPeca(jogada, JogadorAtual.Peca);
        JogadorAtual.AdicionarJogada(jogada);

        if (FimDeJogo()) Encerrar();
    }
    public List<Posicao> ObterJogadasDisponiveis() =>
        Tabuleiro.ObterPosicoesVazias();


    private bool FimDeJogo() => Tabuleiro.VerificarVitoria(JogadorAtual.Peca) || Tabuleiro.VerificarEmpate();
    public bool OcorreuVitoria() => Tabuleiro.VerificarVitoria(JogadorAtual.Peca);

    public bool OcorreuEmpate() => Tabuleiro.VerificarEmpate();

    public bool PossicaoDisponivel(Posicao posicao) =>
        ObterJogadasDisponiveis().Exists(p => p == posicao);

    public void ConfigurarJogadores(string jogador, string adversario)
    {
        Jogador.Nome = jogador;
        Adversario.Nome = adversario;
    }

    public void TrocarTurno()
    {
        JogadorAtual = JogadorAtual == Jogador ? Adversario : Jogador;
    }
}