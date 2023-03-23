using Jogo_da_velha.Logica_jogo.Entidades.Pecas;

namespace Jogo_da_velha.Logica_jogo.Entidades
{
    public class Jogador
    {
        public string Nome { get; private set; }
        public Peca Peca { get; set; }
        public IReadOnlyCollection<Jogada> Jogadas => _jogadasEfetuadas.AsReadOnly();

        private List<Jogada> _jogadasEfetuadas; 
        private int _pontuacao;

        public Jogador(string nome)
        {
            Nome = nome;
            _jogadasEfetuadas = new List<Jogada>();
            _pontuacao = 0;
        }

        public void AdicionarJogada(Jogada jogada) => _jogadasEfetuadas.Add(jogada);
    }
}