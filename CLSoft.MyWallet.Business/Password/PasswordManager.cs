using System;
using System.Threading.Tasks;
using AutoMapper;
using CLSoft.MyWallet.Business.Email;
using CLSoft.MyWallet.Business.Email.Models;
using CLSoft.MyWallet.Business.Password.Models;
using CLSoft.MyWallet.Data.Repositories;

namespace CLSoft.MyWallet.Business.Password
{
    public class PasswordManager : IPasswordManager
    {
        private readonly IAuthRepository _repository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public PasswordManager(IAuthRepository repository, IEmailSender emailSender, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task ChangePasswordAsync(ChangePasswordRequest request)
        {
            var repositoryModel = _mapper.Map<Data.Models.Auth.ChangeUserPasswordRequest>(request);
            await _repository.ChangeUserPasswordAsync(repositoryModel);
        }

        public async Task IssueChangePasswordRequestAsync(IssueChangePasswordRequest request)
        {
            var repositoryModel = _mapper.Map<Data.Models.Auth.ForgotPasswordToken>(request);
            await _repository.AddForgotPasswordTokenAsync(repositoryModel);

            var emailModel = _mapper.Map<SendEmailRequest>(repositoryModel);
            await _emailSender.SendEmailAsync(emailModel);
        }
    }
}