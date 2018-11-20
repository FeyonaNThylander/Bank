using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeyonaBank.Interfaces;
using FeyonaBank.Models;
using FeyonaBank.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FeyonaBank.Controllers
{
    public class TransactionsController : Controller
    {
        private IBankRepository _bankRepo;

        public TransactionsController(IBankRepository bankRepo)
        {
            _bankRepo = bankRepo;
        }

        public IActionResult Verification()
        {
            var viewmodel = new TransactionsViewModel();
            return View(viewmodel);
        }

        public IActionResult DepositAndWithdraw()
        {
            var viewmodel = new TransactionsViewModel();
            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult Deposit(TransactionsViewModel model)
        {
            var customerList = _bankRepo.GetAllCustomers().SelectMany(y => y.BankAccounts);
            var customerAccount = customerList.Where(x => x.AccountId == model.BankAccount.AccountId).SingleOrDefault();

            if (customerAccount == null)
            {
                ViewBag.Message = "The accountnumber is invalid, please enter another number.";
                return View("DepositAndWithdraw", model);
            }

            if (model.Amount == 0)
            {
                ViewBag.Message = "Please enter an amount higher than 0 SEK.";
                return View("DepositAndWithdraw", model);
            }

            if (model.Amount > 0)
            {
                _bankRepo.DepositAmount(model.Amount, customerAccount);
                model.BankAccount.Balance = customerAccount.Balance;

                ViewBag.Message = "You have successfully made a deposit!";
                return View("Verification", model);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Withdraw(TransactionsViewModel model)
        {
            var customerList = _bankRepo.GetAllCustomers().SelectMany(y => y.BankAccounts);
            var customerAccount = customerList.Where(x => x.AccountId == model.BankAccount.AccountId).SingleOrDefault();

            if (customerAccount == null)
            {
                ViewBag.Message = "The accountnumber is incorrect, please enter another number.";
                return View("DepositAndWithdraw", model);
            }

            if (model.Amount == 0)
            {
                ViewBag.Message = "Please enter an amount higher than 0 SEK.";
                return View("DepositAndWithdraw", model);
            }

            if (customerAccount.Balance <= model.Amount)
            {
                ViewBag.Message = "Your amount is more than the total balance of the account, please enter a new amount.";
                return View("DepositAndWithdraw", model);
            }
            else
            {
                _bankRepo.WithdrawAmount(model.Amount, customerAccount);
                model.BankAccount.Balance = customerAccount.Balance;

                ViewBag.Message = "You have successfully made a withdrawl!";
                return View("Verification", model);
            }

        }

    }
}