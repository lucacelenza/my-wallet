using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CLSoft.MyWallet.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}