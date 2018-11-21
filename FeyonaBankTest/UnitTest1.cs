using FeyonaBank.Models;
using FeyonaBank.ViewModels;
using System;
using System.Collections.Generic;
using Xunit;

namespace FeyonaBankTest
{
    public class UnitTest1
    {
        [Fact]
        public void Deposit_Test()
        {

            Account customerAccount = new Account();
            {
                customerAccount.AccountId = 13019;
                customerAccount.Balance = 15000;
            }

            BankRepository _bankRepo = new BankRepository();

            bool expected = true;
            bool actual = _bankRepo.DepositAmount(1000, customerAccount);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Withdraw_Test()
        {

            Account customerAccount = new Account();
            {
                customerAccount.AccountId = 13019;
                customerAccount.Balance = 15000;
            }

            BankRepository _bankRepo = new BankRepository();

            bool expected = true;
            bool actual = _bankRepo.WithdrawAmount(800, customerAccount);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WithdrawTooHighAmount_Test()
        {

            Account customerAccount = new Account();
            {
                customerAccount.AccountId = 13019;
                customerAccount.Balance = 15000;
            }

            BankRepository _bankRepo = new BankRepository();

            bool expected = false;
            bool actual = _bankRepo.WithdrawAmount(17000, customerAccount);

            Assert.Equal(expected, actual);
        }
    }
}
