using Jogo_da_velha.Logica_jogo.Entidades;

namespace Jogo_da_velha.Logica_jogo;

public class Jogo
{
    public bool EmExecucao { get; private set; }
    public Jogador JogadorAtual { get; private set; }
    private Tabuleiro _tabuleiro;
    private Jogador _jogador;
    private Jogador _adversario;

    public Jogo(Jogador jogador, Jogador adversario)
    {
        _jogador = jogador;
        _adversario = adversario;
        _tabuleiro = new();
    }

    private void Iniciar() => EmExecucao = true;
    private void Encerrar() => EmExecucao = false;

    public void RealizarJogada(Jogada jogada)
    {
        if(!EmExecucao) return;

        jogada.Validar(_tabuleiro);

        _tabuleiro.MoverPeca(jogada.Origem, jogada.Destino);

        AlterarTurno();

        if(VerificarTermino()) Encerrar();
    }

    private void AlterarTurno() =>
        JogadorAtual = JogadorAtual == _jogador ? _adversario : _jogador;

    private bool VerificarTermino() => 
        _tabuleiro.VerificarVitoria(JogadorAtual.Peca) || _tabuleiro.VerificarEmpate()


}