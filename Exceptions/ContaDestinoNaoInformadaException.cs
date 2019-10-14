using System;

namespace test.Exceptions
{
    public class ContaDestinoNaoInformadaException : Exception
    {
        public ContaDestinoNaoInformadaException(string msg): base(msg)
        {
            
        }
    }
}