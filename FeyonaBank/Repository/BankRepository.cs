using FeyonaBank.Interfaces;
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


    }
}
