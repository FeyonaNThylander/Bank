using FeyonaBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeyonaBank.ViewModels
{
    public class TransferViewModel
    {
        public Account TransferAccount { get; set; }
        public Account RecieveAccount { get; set; }

        [Range(0, 9999999999999999.99, ErrorMessage = "Please enter valid number")] 
        public decimal Amount { get; set; } 
    }
}
