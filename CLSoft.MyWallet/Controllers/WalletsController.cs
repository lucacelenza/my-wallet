using System;
using System.Threading.Tasks;
using CLSoft.MyWallet.Application.Wallets;
using CLSoft.MyWallet.Models.Wallets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CLSoft.MyWallet.Controllers
{
    [Authorize]
    public class WalletsController : Controller
    {
        private readonly IWalletsControllerService _service;

        public WalletsController(IWalletsControllerService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public IActionResult Add()
        {
            var viewModel = new WalletViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(WalletViewModel viewModel)
        {
            await _service.AddWalletAsync(viewModel);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit(long walletId)
        {
            var viewModel = await _service.GetWalletAsync(walletId);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long walletId, WalletViewModel viewModel)
        {
            await _service.EditWalletAsync(walletId, viewModel);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long walletId)
        {
            var viewModel = await _service.GetWalletAsync(walletId);
            return PartialView(viewModel.Name);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(long walletId)
        {
            await _service.DeleteWalletAsync(walletId);
            return PartialView("Deleted");
        }
    }
}