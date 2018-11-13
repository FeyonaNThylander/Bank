using FeyonaBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeyonaBank.Interfaces
{
    public interface IBankRepository
    {

        List<Customer> GetAllCustomers();
    }
}
