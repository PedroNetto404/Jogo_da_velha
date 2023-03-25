using Jogo_da_velha.Logica_jogo.Entidades.Pecas;
using Jogo_da_velha.Logica_jogo.Exceptions;
using Jogo_da_velha.Logica_jogo.ObjetosDeValor;

namespace Jogo_da_velha.Logica_jogo.Entidades
{
    public class Jogador
    {
        public string Nome { 
            get => _nome;
            set 
            {
                
                if(string.IsNullOrWhiteSpace(value))
                    throw new NomeJogadorInvalidoException(value);
                
                _nome = value;
            }
        }
        public Peca Peca { get; set; }
        public IReadOnlyCollection<Posicao> Jogadas => _jogadasEfetuadas.AsReadOnly();

        private List<Posicao> _jogadasEfetuadas; 
        private int _pontuacao;
        private string _nome;

        public Jogador(Peca peca)
        {
            Peca = peca;
            _jogadasEfetuadas = new List<Posicao>();
            _pontuacao = 0;
        }

        public void AdicionarJogada(Posicao jogada) => _jogadasEfetuadas.Add(jogada);

        public override string ToString()
        {
            return $"{Nome} ({Peca})";
        }
    }
}