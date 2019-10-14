using System;

namespace test.Exceptions
{
    public class ContaNaoEncontradaException : Exception
    {
        public ContaNaoEncontradaException(string msg) : base(msg)
        {
            
        }
    }
}