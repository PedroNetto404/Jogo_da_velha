using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jogo_da_velha.Logica_jogo.Exceptions
{
    public class CasaVaziaException : Exception
    {
        public CasaVaziaException() : base("Não é possível mover uma peça de uma casa vazia.")
        {
            
        }
    }
}