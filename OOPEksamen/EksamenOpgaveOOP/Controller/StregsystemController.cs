using System;
using EksamenOpgaveOOP.Exceptions;
using EksamenOpgaveOOP.CLI;
using EksamenOpgaveOOP.UI;

namespace EksamenOpgaveOOP.Controller
{
    public class StregsystemController : IStregsystemController
    {
        IStregsystemUI StregsystemUI { get; set; }
        IStregsystem Stregsystem { get; set; }
        StregsystemCLI stregsystemCLI { get; set; }
        StregsystemCommandParser StregsystemCommandParser { get;}
        

        public StregsystemController(IStregsystemUI stregsystemCLI, IStregsystem stregsystem)
        {
            Stregsystem = stregsystem;
            StregsystemUI = stregsystemCLI;
            stregsystemCLI.commandEntered += ParseCommand;
            StregsystemCommandParser = new StregsystemCommandParser(this, stregsystemCLI);
        }

        private void ParseCommand(string commandEntered)
        {
            RunCommand(commandEntered);
        }

        private void RunCommand(string command)
        {
            StregsystemCommandParser.ParseCommand(command);
        }

        public void AdminQuit()
        {
            StregsystemUI.Close();
        }

        public void GetUser(string userName)
        {
            try
            {
                User getUserName = Stregsystem.GetUserByUsername(userName);
                StregsystemUI.DisplayUserInfo(getUserName);
                StregsystemUI.DisplayTransactionList(getUserName, 10);
            }
            catch (UserNameNotFoundException user)
            {
                StregsystemUI.DisplayUserNotFound(user.Message);
            }
        }

        public void UserBuyProduct(string userName, string productId)
        {
            try
            {
                int productID = int.Parse(productId);
                User user = Stregsystem.GetUserByUsername(userName);
                Product product = Stregsystem.GetProductByID(productID);

                StregsystemUI.DisplayUserBuysProduct(Stregsystem.BuyProduct(user, product));
            }
            catch (UserNameNotFoundException user)
            {
                StregsystemUI.DisplayUserNotFound(user.Message);
            }
            catch (ProductIdNotFoundException product)
            {
                StregsystemUI.DisplayProductNotFound(product);
            }
            catch (ArgumentNullException e)
            {
                StregsystemUI.DisplayGeneralError(e.Message);
            }
            catch (FormatException)
            {
                StregsystemUI.DisplayGeneralError("Invalid input entered");
            }
            catch (InsufficientCreditsException) 
            {
                StregsystemUI.DisplayInsufficientCash();
            }
        }

        public void MultiBuyProduct(string userName, string count, string productId)
        {
            try
            {
                int productID = Int32.Parse(productId);
                User user = Stregsystem.GetUserByUsername(userName);
                Product product = Stregsystem.GetProductByID(productID);

                StregsystemUI.DisplayUserBuysProduct(int.Parse(count), Stregsystem.MultiBuyProduct(user, int.Parse(count), product));
            }
            catch (UserNameNotFoundException user)
            {
                StregsystemUI.DisplayUserNotFound(user.Message);
            }
            catch (ProductIdNotFoundException product)
            {
                StregsystemUI.DisplayProductNotFound(product);
            }
            catch (ArgumentNullException e)
            {
                StregsystemUI.DisplayGeneralError(e.Message);
            }
            catch (ArgumentOutOfRangeException)
            {
                StregsystemUI.DisplayGeneralError("Invalid count for multi buy");
            }
            catch (FormatException)
            {
                StregsystemUI.DisplayGeneralError("Invalid input entered");
            }
            catch (InsufficientCreditsException)
            {
                StregsystemUI.DisplayInsufficientCash();
            }
        }

        public void ChangeActivateProduct(string state, string id)
        {
            try
            {
                Stregsystem.ChangeActivateProductState(state , int.Parse(id));
                RefreshProductList();
                StregsystemUI.DisplayAdminMessage($"Changed product activity state on product {id} sucessfull!");
            }
            catch (ProductIdNotFoundException product)
            {
                StregsystemUI.DisplayProductNotFound(product);
            }
            catch (FormatException) 
            {
                StregsystemUI.DisplayGeneralError("Product id in wrong format");
            }
            catch (AdminCommandNotFoundException e) 
            {
                StregsystemUI.DisplayAdminCommandNotFoundMessage(e.Message);
            }
        }

        public void ChangeCreditProduct(string state, string id)
        {
            try
            {
                Stregsystem.ChangeCreditProductState(state, int.Parse(id));
                RefreshProductList();
                StregsystemUI.DisplayAdminMessage($"Changed credit state on product {id} sucessfull");
            }
            catch (ProductIdNotFoundException product)
            {
                StregsystemUI.DisplayProductNotFound(product);
            }
            catch (FormatException)
            {
                StregsystemUI.DisplayGeneralError("Product id in wrong format");
            }
            catch (AdminCommandNotFoundException e)
            {
                StregsystemUI.DisplayAdminCommandNotFoundMessage(e.Message);
            }
        }

        public void AddCredits(string userName, string amount) 
        {
            try
            {
                User user = Stregsystem.GetUserByUsername(userName);
                Stregsystem.AddCredits(user, decimal.Parse(amount));
                StregsystemUI.DisplayAdminInsertCredit(decimal.Parse(amount), user);
            }
            catch (UserNameNotFoundException user)
            {
                StregsystemUI.DisplayUserNotFound(user.Message);
            }
            catch (ArgumentException user) 
            {
                StregsystemUI.DisplayUserNotFound(user.Message);
            }
            catch (FormatException) 
            {
                StregsystemUI.DisplayGeneralError("Credits entered is in wrong format");
            }
        }

        private void RefreshProductList()
        {
            try
            {
                Stregsystem.LoadActiveProducts();
                StregsystemUI.MainMenu();
            }
            catch (NullReferenceException e)
            {
                StregsystemUI.DisplayGeneralError(e.Message);
            }
        }
    }
}
