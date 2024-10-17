
using System;

namespace CareerHub.exception
{
    public class NegativeSalaryException : Exception
    {
        public NegativeSalaryException(string message) : base(message)
        {
        }
    }
}
