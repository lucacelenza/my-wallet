using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CLSoft.MyWallet.Business.User;
using CLSoft.MyWallet.Business.Wallets.Exceptions;
using CLSoft.MyWallet.Business.Wallets.Models;
using CLSoft.MyWallet.Data.Repositories;

namespace CLSoft.MyWallet.Business.Wallets
{
    public class UserWalletsProvider : IWalletsProvider
    {
        private readonly IWalletsRepository _repository;
        private readonly IUserIdProvider _userIdProvider;
        private readonly IMapper _mapper;

        public UserWalletsProvider(IWalletsRepository repository, 
            IUserIdProvider userIdProvider, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _userIdProvider = userIdProvider ?? throw new ArgumentNullException(nameof(userIdProvider));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Wallet>> GetAllWalletsAsync(long? selectedWalletId = null)
        {
            var userId = _userIdProvider.GetUserId();
            var wallets = await _repository.GetAllWalletsByUserIdAsync(userId);

            var model = _mapper.Map<IEnumerable<Wallet>>(wallets.OrderBy(w => w.Name));

            if (selectedWalletId.HasValue)
            {
                if (!model.Where(w => w.Id.Equals(selectedWalletId.Value)).Any())
                    throw new SelectedWalletNotFoundException();

                model = model.Select(w => w.Id.Equals(selectedWalletId.Value) ? 
                    new Wallet
                    {
                        Id = w.Id,
                        Name = w.Name,
                        Description = w.Description,
                        CurrentBalance = w.CurrentBalance,
                        IsSelected = true
                    } : w);
            }

            return model;
        }
    }
}