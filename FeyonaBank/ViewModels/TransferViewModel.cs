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
        public decimal Amount { get; set; }
    }
}
