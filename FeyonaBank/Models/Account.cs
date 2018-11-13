using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeyonaBank.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
