using System;
using System.Threading.Tasks;
using CLSoft.MyWallet.Application.Auth;
using CLSoft.MyWallet.Application.Auth.Exceptions;
using CLSoft.MyWallet.Extensions.Attributes;
using CLSoft.MyWallet.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CLSoft.MyWallet.Controllers
{
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

        [AllowAnonymous]
        public IActionResult ChangePassword([RequiredFromQuery]string token)
        {
            return View("ChangePasswordUsingToken");
        }

        [HttpPost]
        [Authorize]
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

        [AllowAnonymous]
        public IActionResult PasswordChanged()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword([RequiredFromQuery]string token, ChangePasswordViewModel viewModel)
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

        [AllowAnonymous]
        public IActionResult TokenExpired()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult PasswordReset()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
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

        [AllowAnonymous]
        public IActionResult Registered()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string returnUrl, LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.LoginAsync(viewModel);

                if (Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }

            return View(viewModel);
        }

        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
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

        [AllowAnonymous]
        public IActionResult ForgotPasswordRequestSent()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction("Login");
        }
    }
}