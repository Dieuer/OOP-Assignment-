using System;
namespace EksamenOpgaveOOP.Exceptions
{
    public class ProductIdNotFoundException : Exception
    {
        public ProductIdNotFoundException(string  productId)
            : base($"{productId}")
        {
            ProductId = productId;
        }

        public ProductIdNotFoundException(string productId, string message)
            : base($"{productId} - {message}")
        {
            ProductId = productId;
        }

        public ProductIdNotFoundException(string productId, string message, Exception innerException)
            : base($"{productId} - {message} - {innerException}")
        {
            ProductId = productId;
        }

        public string ProductId { get; }
    }
}
