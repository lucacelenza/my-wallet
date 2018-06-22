using System;
using System.Threading.Tasks;
using AutoMapper;
using CLSoft.MyWallet.Application.Auth.Exceptions;
using CLSoft.MyWallet.Business.Encryption;
using CLSoft.MyWallet.Business.Identity;
using CLSoft.MyWallet.Business.Password;
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
        private readonly IIdentityManager _identityManager;
        private readonly IPasswordManager _passwordManager;
        private readonly IMapper _mapper;

        public AuthControllerService(
            IAuthRepository repository, IEncryption encryption,
            IIdentityManager identityManager, IPasswordManager passwordManager, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _encryption = encryption ?? throw new ArgumentNullException(nameof(encryption));
            _identityManager = identityManager ?? throw new ArgumentNullException(nameof(identityManager));
            _passwordManager = passwordManager ?? throw new ArgumentNullException(nameof(passwordManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task ChangePasswordAsync(ChangePasswordViewModel viewModel, string token = null)
        {
            try
            {
                await _passwordManager.ChangePasswordAsync(
                    new Business.Password.Models.ChangePasswordRequest(viewModel.Password, token));
            }
            catch (Business.Password.Exceptions.ExpiredTokenException)
            {
                throw new ExpiredChangePasswordRequestException();
            }
        }

        public async Task ForgotPasswordAsync(ForgotPasswordViewModel viewModel)
        {
            try
            {
                await _passwordManager.IssueChangePasswordRequestAsync(
                    new Business.Password.Models.IssueChangePasswordRequest(viewModel.EmailAddress));
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

                var identityModel = _mapper
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
            var request = _mapper.Map<AddUserRequest>(viewModel);
            await _repository.AddUserAsync(request);
        }
    }
}