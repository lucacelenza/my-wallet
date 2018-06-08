using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLSoft.MyWallet.Application.Auth;
using CLSoft.MyWallet.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CLSoft.MyWallet.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IAuthControllerService _service;

        public AuthController(IAuthControllerService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult ChangePassword(string token)
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel viewModel)
        {
            await _service.ChangePasswordAsync(viewModel);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string token, ChangePasswordViewModel viewModel)
        {
            await _service.ChangePasswordAsync(viewModel, token);
            return View();
        }       

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel viewModel)
        {
            await _service.RegisterUserAsync(viewModel);
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            await _service.LoginAsync(viewModel);
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel viewModel)
        {
            await _service.ForgotPasswordAsync(viewModel);
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction("Login");
        }
    }
}