using System;
using System.Collections.Generic;
using System.Text;

namespace EksamenOpgaveOOP.Exceptions
{
    public class AdminCommandNotFoundException : Exception
    {
        public string AdminCommand { get; }
        public AdminCommandNotFoundException(string adminCommand) 
            :base($"{adminCommand}")
        {
            AdminCommand = adminCommand;
        }
        public AdminCommandNotFoundException(string adminCommand, string message)
            : base($"{adminCommand} - {message}")
        {
            AdminCommand = adminCommand;
        }
        public AdminCommandNotFoundException(string adminCommand, string message, Exception innerException)
            : base($"{adminCommand} - {message} - {innerException}")
        {
            AdminCommand = adminCommand;
        }
    }
}
