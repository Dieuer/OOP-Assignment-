using System;
namespace EksamenOpgaveOOP.Controller
{
    public interface IStregsystemController
    {
        void ChangeActivateProduct(string state, string id);
        void ChangeCreditProduct(string state, string id);
        void GetUser(string userName);
        void MultiBuyProduct(string userName, string count, string productId);
        void UserBuyProduct(string userName, string productId);
        void AdminQuit();
        void AddCredits(string userName, string amount);
    }
}
