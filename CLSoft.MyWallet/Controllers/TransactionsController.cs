using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLSoft.MyWallet.Application.Transactions;
using CLSoft.MyWallet.Models.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CLSoft.MyWallet.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly ITransactionsControllerService _service;

        public TransactionsController(ITransactionsControllerService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _service.GetTransactionsAsync();
            return View(viewModel);
        }

        public async Task<IActionResult> Index(long walletId)
        {
            var viewModel = await _service
                .GetTransactionsAsync(new GetTransactionsRequest { WalletId = walletId });

            return View(viewModel);
        }

        public async Task<IActionResult> GetTransactions(GetTransactionsRequest request)
        {
            var viewModel = await _service.GetTransactionsAsync(request);
            return PartialView(viewModel);
        }

        public async Task<IActionResult> Add()
        {
            var viewModel = await _service.GetTransactionAsync();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(TransactionViewModel viewModel)
        {
            await _service.AddTransactionAsync(viewModel);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(long transactionId)
        {
            var viewModel = await _service.GetTransactionAsync(transactionId);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long transactionId, TransactionViewModel viewModel)
        {
            await _service.EditTransactionAsync(transactionId, viewModel);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long transactionId)
        {
            var transaction = await _service.GetTransactionAsync(transactionId);
            return View(transaction.Description);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(long transactionId)
        {
            await _service.DeleteTransactionAsync(transactionId);
            return View();
        }
    }
}