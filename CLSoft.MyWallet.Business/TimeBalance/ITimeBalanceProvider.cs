using CLSoft.MyWallet.Business.TimeBalance.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Business.TimeBalance
{
    public interface ITimeBalanceProvider
    {
        Task<IDictionary<string, decimal>> GetTimeBalanceAsync(GetTimeBalanceRequest request);
    }
}