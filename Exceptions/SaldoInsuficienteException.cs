using System;

namespace test.Exceptions
{
    public class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException(string msg) : base(msg)
        {
            
        }
    }
}