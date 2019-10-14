using System;

namespace test.Exceptions
{
    public class EntradaInvalidaException : Exception
    {
        public EntradaInvalidaException(string msg) : base(msg)
        {
            
        }
    }
}