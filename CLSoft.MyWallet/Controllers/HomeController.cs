using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CLSoft.MyWallet.Models;
using Microsoft.AspNetCore.Authorization;
using CLSoft.MyWallet.Application.Home;

namespace CLSoft.MyWallet.Controllers
{
    public class HomeController : Controller
    {
        private IHomeControllerService _service;

        public HomeController(IHomeControllerService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var viewModel = await _service.GetDashboardViewModelAsync();
            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}