using CLSoft.MyWallet.Business.User;
using CLSoft.MyWallet.Data.Models.Wallets;
using CLSoft.MyWallet.Data.Repositories;
using CLSoft.MyWallet.Exceptions;
using CLSoft.MyWallet.Mappings;
using CLSoft.MyWallet.Models.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Application.Wallets
{
    public class WalletsControllerService : IWalletsControllerService
    {
        private readonly IWalletsRepository _repository;
        private readonly IAsyncUserIdProvider _userIdProvider;

        public WalletsControllerService(IWalletsRepository repository, IAsyncUserIdProvider userIdProvider)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _userIdProvider = userIdProvider ?? throw new ArgumentNullException(nameof(userIdProvider));
        }

        public async Task<WalletViewModel> GetWalletAsync(long walletId)
        {
            var userId = await _userIdProvider.GetUserIdAsync();
            var repositoryModel = await _repository.GetWalletByIdAsync(walletId);

            if (repositoryModel.UserId != userId)
                throw new NotAuthorizedException();

            return Mapper.Current.Map<WalletViewModel>(repositoryModel);
        }

        public async Task AddWalletAsync(WalletViewModel viewModel)
        {
            var request = Mapper.Current.Map<AddWalletRequest>(viewModel);
            await _repository.AddWalletAsync(request);
        }

        public async Task EditWalletAsync(long walletId, WalletViewModel viewModel)
        {
            var request = Mapper.Current.Map<EditWalletRequest>(viewModel);
            request.WalletId = walletId;
            await _repository.EditWalletAsync(request);
        }

        public async Task DeleteWalletAsync(long walletId)
        {
            await _repository.DeleteWalletByIdAsync(walletId);
        }

        public async Task<WalletsViewModel> GetAllWalletsAsync()
        {
            var userId = await _userIdProvider.GetUserIdAsync();
            var wallets = await _repository.GetAllWalletsByUserIdAsync(userId);

            return Mapper.Current.Map<WalletsViewModel>(wallets);
        }
    }
}