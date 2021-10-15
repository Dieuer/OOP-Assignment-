using System;

namespace EksamenOpgaveOOP.Exceptions
{
    public class InsufficientCreditsException : Exception
    {
        public InsufficientCreditsException()
            : base($"Insufficient creadits")
        {
        }

        public InsufficientCreditsException(string message)
            : base($"Insufficient creadits {message}")
        {
        }

        public InsufficientCreditsException(string message, Exception innerException)
            : base($"Insufficient creadits {message} - {innerException}")
        {
        }
    }
}
