using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jogo_da_velha.Logica_jogo.Exceptions;

namespace Jogo_da_velha.Logica_jogo.Entidades
{
    public class Jogada
    {
        public Posicao Origem { get; set; }
        public Posicao Destino { get; private set; }

        public Jogada(Posicao origem, Posicao destino)
        {
            Origem = origem;
            Destino = destino;
        }

        public void Validar(Tabuleiro tabuleiro)
        {
            if(tabuleiro.CasaEstaVazia(Origem))
                throw new CasaVaziaException();

            if(!tabuleiro.CasaEstaVazia(Destino))
                throw new CasaOcupadaException();
        }
    }
}