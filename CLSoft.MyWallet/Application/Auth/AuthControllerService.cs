using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLSoft.MyWallet.Business.Email;
using CLSoft.MyWallet.Business.Encryption;
using CLSoft.MyWallet.Business.Time;
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

        public AuthControllerService(
            IAuthRepository repository, IEncryption encryption, IEmailSender emailSender)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _encryption = encryption ?? throw new ArgumentNullException(nameof(encryption));
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
        }

        public async Task ChangePasswordAsync(ChangePasswordViewModel viewModel, string token = null)
        {
            var request = Mapper.Current.Map<ChangeUserPasswordRequest>(viewModel);

            if (!string.IsNullOrEmpty(token))
            {
                var forgotPasswordToken = await _repository
                    .GetForgotPasswordTokenByTokenAsync(token);

                if (forgotPasswordToken.ExpiresOn < TimeProvider.Current.Now)
                    ; //throw exception

                request.UserId = forgotPasswordToken.UserId;
            }

            await _repository.ChangeUserPasswordAsync(request);
        }

        public async Task ForgotPasswordAsync(ForgotPasswordViewModel viewModel)
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

        public async Task LoginAsync(LoginViewModel viewModel)
        {
            var user = await _repository
                .GetUserByEmailAddressAsync(viewModel.EmailAddress);

            if (!_encryption.Validate(viewModel.Password, user.HashedPassword))
                ; //throw exception

            //store user cookie
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public async Task RegisterUserAsync(RegisterUserViewModel viewModel)
        {
            var request = Mapper.Current.Map<AddUserRequest>(viewModel);
            await _repository.AddUserAsync(request);
        }
    }
}