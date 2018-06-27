using System.Security.Claims;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Business.Identity
{
    public interface IIdentityValidator
    {
        Task ValidatePrincipalAsync(ClaimsPrincipal principal);
    }
}