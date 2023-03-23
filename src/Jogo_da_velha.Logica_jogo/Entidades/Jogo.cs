using Jogo_da_velha.Logica_jogo.Entidades;

namespace Jogo_da_velha.Logica_jogo;

public class Jogo
{
    public bool EmExecucao { get; private set; }
    public Jogador JogadorAtual { get; private set; }
    public Tabuleiro Tabuleiro {get; private set;}
    private Jogador _jogador;
    private Jogador _adversario;

    public Jogo(Jogador jogador, Jogador adversario)
    {
        _jogador = jogador;
        _adversario = adversario;
        Tabuleiro = new();
        JogadorAtual = _jogador;
    }

    public void Iniciar() => EmExecucao = true;
    public void Encerrar() => EmExecucao = false;

    public void RealizarJogada(Posicao jogada)
    {
        if(!EmExecucao) return;

        Tabuleiro.ColocarPeca(jogada, JogadorAtual.Peca);

        AlterarTurno();

        if(VerificarTermino()) Encerrar();
    }
    public List<Posicao> ObterJogadasDisponiveis() =>
        Tabuleiro.ObterPosicoesVazias();
    public bool JogadaValida(Posicao posicao) =>
        Tabuleiro.CasaEstaVazia(posicao);

    private void AlterarTurno() =>
        JogadorAtual = JogadorAtual == _jogador ? _adversario : _jogador;

    private bool VerificarTermino() => 
        Tabuleiro.VerificarVitoria(JogadorAtual.Peca) || Tabuleiro.VerificarEmpate();
public bool OcorreuVitoria() => Tabuleiro.VerificarVitoria(JogadorAtual.Peca);

    public bool OcorreuEmpate() => Tabuleiro.VerificarEmpate();
}