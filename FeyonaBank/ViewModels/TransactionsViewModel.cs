using FeyonaBank.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeyonaBank.ViewModels
{
    public class TransactionsViewModel
    {
        [Required]
        public Account BankAccount { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
