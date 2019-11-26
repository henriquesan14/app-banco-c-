using System;

namespace test.Exceptions
{
    public class TransferenciaInvalidaException : Exception
    {
        public TransferenciaInvalidaException(string msg) : base(msg)
        {
            
        }
    }
}