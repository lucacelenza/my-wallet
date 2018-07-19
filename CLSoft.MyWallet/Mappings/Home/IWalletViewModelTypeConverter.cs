using AutoMapper;
using CLSoft.MyWallet.Business.Wallets.Models;
using CLSoft.MyWallet.Models.Home;
using System;

namespace CLSoft.MyWallet.Mappings.Home
{
    public class IWalletViewModelTypeConverter : ITypeConverter<Wallet, IWalletViewModel>
    {
        private readonly IMapper _mapper;

        public IWalletViewModelTypeConverter(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IWalletViewModel Convert(Wallet source, IWalletViewModel destination, ResolutionContext context)
        {
            if (source.IsSelected)
                return _mapper.Map<SelectedWalletViewModel>(source);
            else
                return _mapper.Map<WalletViewModel>(source);
        }
    }
}
