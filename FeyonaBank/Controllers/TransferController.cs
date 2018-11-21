using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeyonaBank.Interfaces;
using FeyonaBank.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FeyonaBank.Controllers
{
    public class TransferController : Controller
    {
        private IBankRepository _bankRepo;

        public TransferController(IBankRepository bankRepo)
        {
            _bankRepo = bankRepo;
        }
        public IActionResult Transfer()
        {
            var model = new TransferViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Transfer(TransferViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var result = _bankRepo.Transfer(vm);

                return PartialView("_TransferPartial", result);

            }
            return RedirectToAction("Transfer");
        }
    }
}