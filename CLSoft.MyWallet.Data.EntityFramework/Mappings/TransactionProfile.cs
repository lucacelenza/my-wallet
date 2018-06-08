using AutoMapper;
using CLSoft.MyWallet.Data.Models.Transactions;

namespace CLSoft.MyWallet.Data.EntityFramework.Mappings
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<AddTransactionRequest, Entities.Transaction>();
            CreateMap<Entities.Transaction, Transaction>();
        }
    }
}