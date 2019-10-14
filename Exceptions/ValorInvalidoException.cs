using System;

namespace test.Exceptions
{
    public class ValorInvalidoException : Exception
    {
        public ValorInvalidoException(string msg) : base(msg)
        {
            
        }
    }
}