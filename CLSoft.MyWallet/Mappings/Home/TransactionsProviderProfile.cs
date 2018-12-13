using AutoMapper;
using CLSoft.MyWallet.Business.Transactions.Models;
using CLSoft.MyWallet.Models.Home;

namespace CLSoft.MyWallet.Mappings.Home
{
    public class TransactionsProviderProfile : Profile
    {
        public TransactionsProviderProfile()
        {
            CreateMap<Transaction, TransactionViewModel>();
        }
    }
}
