using System;
namespace EksamenOpgaveOOP.Exceptions
{
    public class UserNameNotFoundException : Exception
    {
        public UserNameNotFoundException(string user)
            : base($"{user}")
        {
        }

        public UserNameNotFoundException(string user, string message)
            : base($"{user} - {message}")
        {
        }

        public UserNameNotFoundException(string user, string message, Exception innerException)
            : base($"{user} - {message} - {innerException}")
        {
        }
    }
}
