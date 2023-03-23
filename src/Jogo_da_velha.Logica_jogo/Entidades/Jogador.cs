using Jogo_da_velha.Logica_jogo.Entidades.Pecas;

namespace Jogo_da_velha.Logica_jogo.Entidades
{
    public class Jogador
    {
        public string Nome { get; private set; }
        public Peca Peca { get; set; }
        public IReadOnlyCollection<Posicao> Jogadas => _jogadasEfetuadas.AsReadOnly();

        private List<Posicao> _jogadasEfetuadas; 
        private int _pontuacao;

        public Jogador(string nome, Peca peca)
        {
            Nome = nome;
            Peca = peca;
            _jogadasEfetuadas = new List<Posicao>();
            _pontuacao = 0;
        }

        public void AdicionarJogada(Posicao jogada) => _jogadasEfetuadas.Add(jogada);
    }
}