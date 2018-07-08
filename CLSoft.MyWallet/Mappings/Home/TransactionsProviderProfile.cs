using AutoMapper;
using CLSoft.MyWallet.Business.Transactions.Models;
using CLSoft.MyWallet.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
