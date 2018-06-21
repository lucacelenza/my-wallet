using System;
using System.Threading.Tasks;
using CLSoft.MyWallet.Business.Email;
using CLSoft.MyWallet.Business.Email.Models;
using CLSoft.MyWallet.Business.Password.Models;
using CLSoft.MyWallet.Data.Repositories;
using CLSoft.MyWallet.Mappings;

namespace CLSoft.MyWallet.Business.Password
{
    public class PasswordManager : IPasswordManager
    {
        private readonly IAuthRepository _repository;
        private readonly IEmailSender _emailSender;

        public PasswordManager(IAuthRepository repository, IEmailSender emailSender)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
        }

        public async Task ChangePasswordAsync(ChangePasswordRequest request)
        {
            var repositoryModel = Mapper.Current.Map<Data.Models.Auth.ChangeUserPasswordRequest>(request);
            await _repository.ChangeUserPasswordAsync(repositoryModel);
        }

        public async Task IssueChangePasswordRequestAsync(IssueChangePasswordRequest request)
        {
            var repositoryModel = Mapper.Current.Map<Data.Models.Auth.ForgotPasswordToken>(request);
            await _repository.AddForgotPasswordTokenAsync(repositoryModel);

            var emailModel = Mapper.Current.Map<SendEmailRequest>(repositoryModel);
            await _emailSender.SendEmailAsync(emailModel);
        }
    }
}