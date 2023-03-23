using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jogo_da_velha.Logica_jogo.Exceptions
{
    public class CasaOcupadaException : Exception
    {
        public CasaOcupadaException() : base("Não é possível colocar uma peça em uma casa ocupada.")
        {
            
        }
    }
}