using System;
using EksamenOpgaveOOP.CLI;
using EksamenOpgaveOOP.Controller;
using EksamenOpgaveOOP.UI;


namespace EksamenOpgaveOOP.Controller
{
    public class StregsystemCommandParser
    {
        IStregsystemController StregsystemController { get; set; }
        IStregsystemUI StregsystemCLI { get; set; }

        public StregsystemCommandParser(IStregsystemController stregsystemController, IStregsystemUI stregsystemCLI)
        {
            StregsystemController = stregsystemController;
            StregsystemCLI = stregsystemCLI;
        }

        public void ParseCommand(string commandEntered)
        {
            string[] lines = commandEntered.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length == 1)
            {
                if (lines[0].StartsWith(":"))
                {
                    if ((lines[0] == ":quit" || lines[0] == ":q"))
                    {
                        StregsystemController.AdminQuit();
                    }
                    else
                    {
                        StregsystemCLI.DisplayAdminCommandNotFoundMessage(lines[0]);
                    }
                }
                else
                {
                    StregsystemController.GetUser(lines[0]);
                }
            }

            if (lines.Length == 2)
            {
                if (lines[0].StartsWith(":"))
                {
                    switch (lines[0])
                    {
                        case ":activate":
                            StregsystemController.ChangeActivateProduct(lines[0], lines[1]);
                            break;
                        case ":deactivate":
                            StregsystemController.ChangeActivateProduct(lines[0], lines[1]);
                            break;
                        case ":crediton":
                            StregsystemController.ChangeCreditProduct(lines[0], lines[1]);
                            break;
                        case ":creditoff":
                            StregsystemController.ChangeCreditProduct(lines[0], lines[1]);
                            break;
                        default:
                            StregsystemCLI.DisplayAdminCommandNotFoundMessage(lines[0]);
                            break;
                    }
                }
                else
                {
                    StregsystemController.UserBuyProduct(lines[0], lines[1]);
                }
            }
            if (lines.Length == 3)
            {
                if (lines[0].StartsWith(":"))
                {
                    if (lines[0] == ":addcredits")
                    {
                        StregsystemController.AddCredits(lines[1], lines[2]);
                    }
                    else
                    {
                        StregsystemCLI.DisplayAdminCommandNotFoundMessage(lines[0]);
                    }
                }
                else
                {
                    StregsystemController.MultiBuyProduct(lines[0], lines[1], lines[2]);
                }
            }

            if (lines.Length > 3)
            {
                StregsystemCLI.DisplayGeneralError("Invalid input entered");
            }
        }
    }
}
