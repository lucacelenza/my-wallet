using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLSoft.MyWallet.Application.Auth.Exceptions;
using CLSoft.MyWallet.Business.Email;
using CLSoft.MyWallet.Business.Encryption;
using CLSoft.MyWallet.Business.Identity;
using CLSoft.MyWallet.Business.Time;
using CLSoft.MyWallet.Data.Exceptions;
using CLSoft.MyWallet.Data.Models.Auth;
using CLSoft.MyWallet.Data.Repositories;
using CLSoft.MyWallet.Mappings;
using CLSoft.MyWallet.Models.Auth;

namespace CLSoft.MyWallet.Application.Auth
{
    public class AuthControllerService : IAuthControllerService
    {
        private readonly IAuthRepository _repository;
        private readonly IEncryption _encryption;
        private readonly IEmailSender _emailSender;
        private readonly IIdentityManager _identityManager;

        public AuthControllerService(
            IAuthRepository repository, IEncryption encryption, IEmailSender emailSender,
            IIdentityManager identityManager)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _encryption = encryption ?? throw new ArgumentNullException(nameof(encryption));
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
            _identityManager = identityManager ?? throw new ArgumentNullException(nameof(identityManager));
        }

        public async Task ChangePasswordAsync(ChangePasswordViewModel viewModel, string token = null)
        {
            var request = Mapper.Current.Map<ChangeUserPasswordRequest>(viewModel);

            if (!string.IsNullOrEmpty(token))
            {
                var forgotPasswordToken = await _repository
                    .GetForgotPasswordTokenByTokenAsync(token);

                if (forgotPasswordToken.ExpiresOn < TimeProvider.Current.Now)
                    throw new ExpiredChangePasswordRequestException();

                request.UserId = forgotPasswordToken.UserId;
            }

            await _repository.ChangeUserPasswordAsync(request);
        }

        public async Task ForgotPasswordAsync(ForgotPasswordViewModel viewModel)
        {
            try
            {
                var user = await _repository
                    .GetUserByEmailAddressAsync(viewModel.EmailAddress);

                var token = new Data.Models.Auth.ForgotPasswordToken
                {
                    Token = Guid.NewGuid().ToString(),
                    UserId = user.Id,
                    RegisteredOn = TimeProvider.Current.Now,
                    ExpiresOn = TimeProvider.Current.Now.AddHours(1)
                };

                await _repository.AddForgotPasswordTokenAsync(token);

                await _emailSender.SendEmailAsync(new Business.Email.Models.SendEmailRequest
                {
                    To = user.EmailAddress,
                    Subject = "",
                    Template = "",
                    Model = new { }
                });
            }
            catch (DataNotFoundException)
            {

            }
        }

        public async Task LoginAsync(LoginViewModel viewModel)
        {
            try
            {            
                var user = await _repository
                    .GetUserByEmailAddressAsync(viewModel.EmailAddress);

                if (!_encryption.Validate(viewModel.Password, user.HashedPassword))
                    throw new InvalidEmailOrPasswordException();

                var identityModel = Mapper.Current
                    .Map<Business.Identity.Models.SignInRequest>(viewModel);

                await _identityManager.SignInAsync(identityModel);
            }
            catch (DataNotFoundException)
            {
                throw new InvalidEmailOrPasswordException();
            }
        }

        public async Task LogoutAsync()
        {
            await _identityManager.SignOutAsync();
        }

        public async Task RegisterUserAsync(RegisterUserViewModel viewModel)
        {
            var request = Mapper.Current.Map<AddUserRequest>(viewModel);
            await _repository.AddUserAsync(request);
        }
    }
}