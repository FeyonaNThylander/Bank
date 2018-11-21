using FeyonaBank.Interfaces;
using FeyonaBank.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FeyonaBank.Models
{
    public class BankRepository : IBankRepository
    {

        private static List<Customer> CustomerList;

        public List<Customer> GetAllCustomers()
        {
            if (CustomerList == null)
            {
                CustomerList = new List<Customer>();

                CustomerList.Add(new Customer()
                {
                    Id = 1005,
                    OrgNumber = "559268-7528",
                    CompanyName = "ICA Bomben",
                    Address = "Hökarängsvägen 8",
                    ZipCode = "S-12356",
                    City = "Farsta",
                    Country = "Sweden",
                    Telephone = "08-4656930",
                    BankAccounts = new List<Account>()
                {
                    new Account
                    {
                        AccountId = 13019,
                        Balance = 15000
                    },
                    new Account
                    {
                        AccountId = 13020,
                        Balance = 60000
                    }

                }
                });

                CustomerList.Add(new Customer()
                {
                    Id = 1024,
                    OrgNumber = "456392-8406",
                    CompanyName = "Bagarn o Konditorin",
                    Address = "Vallhallavägen 24",
                    ZipCode = "S-12357",
                    City = "Stockholm",
                    Country = "Sweden",
                    Telephone = "073-7503765",
                    BankAccounts = new List<Account>()
                {
                    new Account
                    {
                        AccountId = 13093,
                        Balance = 69558
                    },
                }
                });

                CustomerList.Add(new Customer()
                {
                    Id = 1032,
                    OrgNumber = "571553-1910",
                    CompanyName = "Studio Mo Leah",
                    Address = "Vaniljvägen 100",
                    ZipCode = "S-957602",
                    City = "Göteborg",
                    Country = "Sweden",
                    Telephone = "070-44876890",
                    BankAccounts = new List<Account>()
                {
                    new Account
                    {
                        AccountId = 13128,
                        Balance = 39200
                    },
                     new Account
                    {
                        AccountId = 13130,
                        Balance = 48070
                    }
                }
                });
            }

            return CustomerList;
        }

        public bool DepositAmount(int amount, Account bankAccount)
        {
            bankAccount.Balance += amount;

            return true;
        }

        public bool WithdrawAmount(int amount, Account bankAccount)
        {
            if (bankAccount.Balance < amount)
            {
                return false;
            }

            if (bankAccount.Balance >= amount)
            {
                bankAccount.Balance -= amount;
            }
            return true;
        }

        public bool IsCorrectAccountNo(int accountNo)
        {
            List<Account> foundAccount = new List<Account>();
            foreach (var cust in CustomerList)
            {
                foundAccount = cust.BankAccounts.Where(a => a.AccountId == accountNo).ToList();

                if (foundAccount.Any())
                {
                    return true;

                }
            }

            return false;

        }

        public string Transfer(TransferViewModel model)
        {
            if(model.Amount == 0)
            {
                return "<p>You can't transfer 0 SEK.</p>";
            }
            var recieverIsExistingAccount = IsCorrectAccountNo(model.RecieveAccount.AccountId);
            var transferIsExistingAccount = IsCorrectAccountNo(model.TransferAccount.AccountId);
            if (!recieverIsExistingAccount || !transferIsExistingAccount)
            {
                return "<p>You haven't filled in a valid account number, try again!</p>";
            }

            else
            {
                Account RecieveAccount;
                Account TransferAccount;
                foreach (var cust in CustomerList)
                {
                    RecieveAccount = cust.BankAccounts.Where(a => a.AccountId == model.RecieveAccount.AccountId).FirstOrDefault();
                    TransferAccount = cust.BankAccounts.Where(a => a.AccountId == model.TransferAccount.AccountId).FirstOrDefault();


                    var result = PerformTransfer(RecieveAccount, TransferAccount, model.Amount);

                    if (!result)
                    {
                        return "<p>Your balance is too low.</p>";
                    }
                    else
                    {
                    return string.Format("<h4>Account {0} transferred {1} SEK to account {2}.</h4> <h5><b>Current Balance</b></h5> <p>{0} : {3} SEK</p> <p>{2} : {4} SEK", TransferAccount.AccountId, model.Amount, RecieveAccount.AccountId, TransferAccount.Balance, RecieveAccount.Balance);

                    }


                }
                return "<p>Something went wrong, try again!</p>";
            }


        }

        public bool PerformTransfer(Account recieveAccount, Account transferAccount, decimal amount)
        {
            if (transferAccount.Balance < amount)
            {
                return false;
            }
            else
            {
                transferAccount.Balance -= (int)amount;
                recieveAccount.Balance += (int)amount;
                return true;
            }
        }
    }
}
