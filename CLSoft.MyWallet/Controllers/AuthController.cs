using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLSoft.MyWallet.Application.Auth;
using CLSoft.MyWallet.Application.Auth.Exceptions;
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
            return View("ChangePasswordUsingToken");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.ChangePasswordAsync(viewModel);
                return RedirectToAction("PasswordChanged");
            }

            return View(viewModel);
        }

        public IActionResult PasswordChanged()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string token, ChangePasswordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.ChangePasswordAsync(viewModel, token);
                    return RedirectToAction("PasswordReset");
                }
                catch (ExpiredChangePasswordRequestException)
                {
                    return RedirectToAction("TokenExpired");
                }
            }
            
            return View("ChangePasswordUsingToken", viewModel);
        }

        public IActionResult TokenExpired()
        {
            return View();
        }

        public IActionResult PasswordReset()
        {
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
            if (ModelState.IsValid)
            {
                await _service.RegisterUserAsync(viewModel);
                return RedirectToAction("Registered");
            }
            
            return View(viewModel);
        }

        public IActionResult Registered()
        {
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
            if (ModelState.IsValid)
            {
                await _service.LoginAsync(viewModel);
                return RedirectToAction("Index", "Home");
            }

            return View(viewModel);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.ForgotPasswordAsync(viewModel);
                return RedirectToAction("ForgotPasswordRequestSent");
            }
            
            return View(viewModel);
        }

        public IActionResult ForgotPasswordRequestSent()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction("Login");
        }
    }
}