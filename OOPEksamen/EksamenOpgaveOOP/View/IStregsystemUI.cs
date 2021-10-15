using EksamenOpgaveOOP.Exceptions;
using System;
namespace EksamenOpgaveOOP.UI
{
    public interface IStregsystemUI
    {
        void MainMenu();
        void Start();
        void Close();
        void DisplayProductNotFound(ProductIdNotFoundException product);
        void DisplayUserInfo(User user);
        void DisplayUserNotFound(string user);
        void DisplayAdminCommandNotFoundMessage(string command);
        void DisplayGeneralError(string errorString);
        void DisplayInsufficientCash();
        void DisplayUserBuysProduct(BuyTransaction transaction);
        void DisplayUserBuysProduct(int count, BuyTransaction transaction);
        void DisplayAdminMessage(string message);
        void DisplayAdminInsertCredit(decimal amount, User user);
        void DisplayTransactionList(User user, int count);

        delegate void CommandEntered(string commandEntered);
    }

}
