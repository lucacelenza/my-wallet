using AutoMapper;
using CLSoft.MyWallet.Data.Models.Auth;
using CLSoft.MyWallet.Models.Auth;

namespace CLSoft.MyWallet.Mappings.Auth
{
    public class DepositTransactionValueResolver 
        : IValueResolver<RegisterUserViewModel.StartWalletViewModel, AddUserRequest.Wallet.Transaction, string>
    {
        public string Resolve(
            RegisterUserViewModel.StartWalletViewModel source, 
            AddUserRequest.Wallet.Transaction destination, string destMember, 
            ResolutionContext context)
        {
            return $"Registered deposit for {source.Name} wallet.";
        }
    }
}
