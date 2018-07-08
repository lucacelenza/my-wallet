using AutoMapper;
using CLSoft.MyWallet.Data.Models.Transactions;

namespace CLSoft.MyWallet.Data.EntityFramework.Mappings
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<AddTransactionRequest, Entities.Transaction>();
            CreateMap<Entities.Transaction, Transaction>()
                .ForMember(d => d.WalletName, o => o.MapFrom(s => s.Wallet.Name));
        }
    }
}