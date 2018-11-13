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

        List<Customer> customerList = new List<Customer>();


        public List<Customer> GetAllCustomers()
        {
            customerList.Add(new Customer()
            {
                Id = 1005,
                OrgNumber = "559268-7528",
                CompanyName = "ICA Bomben",
                Address = "Hökarängsvägen 8",
                ZipCode = "S-12356",
                City = "Farsta",
                Country = "Sweden",
                Telephone = "070-46569308",
                BankAccounts = new List<Account>()
                {
                    new Account
                    {
                        Id = 1005,
                        AccountNumber = 13019,
                        Balance = 148800
                    },
                    new Account
                    {
                        Id = 1005,
                        AccountNumber = 13020,
                        Balance = 613603
                    }

                }
            });

            customerList.Add(new Customer()
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
                        Id = 1024,
                        AccountNumber = 13093,
                        Balance = 69558
                    },
                }
            });

            customerList.Add(new Customer()
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
                        Id = 1032,
                        AccountNumber = 13128,
                        Balance = 39200
                    },
                     new Account
                    {
                        Id = 1032,
                        AccountNumber = 13130,
                        Balance = 48070
                    }
                }
            });

            return customerList;
        }

    }
}
