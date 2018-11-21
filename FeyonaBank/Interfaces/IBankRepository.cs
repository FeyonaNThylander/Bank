using FeyonaBank.Models;
using FeyonaBank.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeyonaBank.Interfaces
{
    public interface IBankRepository
    {

        List<Customer> GetAllCustomers();

        bool DepositAmount(int amount, Account bankAccount);
        bool WithdrawAmount(int amount, Account bankAccount);
        string Transfer(TransferViewModel model);
        bool PerformTransfer(Account recieveAccount, Account transferAccount, decimal amount);
    }
}
