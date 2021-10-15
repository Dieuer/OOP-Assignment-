using System;
namespace EksamenOpgaveOOP.Exceptions
{
    public class ProductIsNotActiveException : Exception
    {
        public ProductIsNotActiveException(Product product)
            : base($"{product} is inactive")
        {
        }

        public ProductIsNotActiveException(Product product, string message)
            : base($"{product} - {message}")
        {
        }

        public ProductIsNotActiveException(Product product, string message, Exception innerException)
            : base($"{product} - {message} - {innerException}")
        {
        }
    }
}
