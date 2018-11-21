using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeyonaBank.Models;
using FeyonaBank.Interfaces;
using FeyonaBank.ViewModels;

namespace FeyonaBank.Controllers
{
    public class HomeController : Controller
    {
        private IBankRepository _bankRepo;

        public HomeController(IBankRepository bankRepo)
        {
            _bankRepo = bankRepo;
        }


        public IActionResult Index()
        {
            var model = new CustomerAccountViewModel()
            {
                Customers = _bankRepo.GetAllCustomers()
            };

            return View(model);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
