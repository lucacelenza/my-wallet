using AutoMapper;
using CLSoft.MyWallet.Business.Time;
using CLSoft.MyWallet.Data.Models.Transactions;
using CLSoft.MyWallet.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Mappings.Transactions
{
    public class TransactionsProfile : Profile
    {
        public TransactionsProfile()
        {
            CreateMap<TransactionViewModel, AddTransactionRequest>()
                .ForMember(d => d.RegisteredOn, o => o.UseValue(TimeProvider.Current.Now));

            CreateMap<TransactionViewModel, EditTransactionRequest>()
                .ForMember(d => d.UpdatedOn, o => o.UseValue(TimeProvider.Current.Now));

            CreateMap<Transaction, TransactionViewModel>();

            CreateMap<IEnumerable<Transaction>, TransactionsViewModel>()
                .ForMember(d => d.Transactions, o => o.MapFrom(s => s));
        }
    }
}