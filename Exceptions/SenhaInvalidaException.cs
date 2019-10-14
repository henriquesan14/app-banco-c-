using System;

namespace test.Exceptions
{
    public class SenhaInvalidaException : Exception
    {
       public SenhaInvalidaException(string msg) :  base(msg)
       {
           
       } 
    }
}