using CLSoft.MyWallet.Data.EntityFramework.Configuration;
using CLSoft.MyWallet.Data.Exceptions;
using CLSoft.MyWallet.Data.Models.Auth;
using CLSoft.MyWallet.Data.Repositories;
using CLSoft.MyWallet.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Data.EntityFramework.Repositories
{
    public class EntityFrameworkAuthRepository : EntityFrameworkRepository, IAuthRepository
    {
        public EntityFrameworkAuthRepository(MyWalletDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddForgotPasswordTokenAsync(ForgotPasswordToken token)
        {
            var entity = Mapper.Current.Map<Entities.ForgotPasswordToken>(token);
            DbContext.ForgotPasswordTokens.Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task AddUserAsync(AddUserRequest request)
        {
            var entity = Mapper.Current.Map<Entities.User>(request);
            DbContext.Users.Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task ChangeUserPasswordAsync(ChangeUserPasswordRequest request)
        {
            var entity = await DbContext.Users
                .FirstOrDefaultAsync(u => u.Id.Equals(request.UserId));

            if (entity == null)
                throw new DataNotFoundException();

            entity.HashedPassword = request.NewHashedPassword;
            entity.PasswordChangedOn = request.ChangedOn;

            await DbContext.SaveChangesAsync();
        }

        public async Task<ForgotPasswordToken> GetForgotPasswordTokenByTokenAsync(string token)
        {
            var entity = await QueryForgotPasswordTokensCollectionByToken(token)
                .FirstOrDefaultAsync();

            return MapEntityToForgotPasswordToken(entity);
        }

        public User GetUserByEmailAddress(string emailAddress)
        {
            var entity = QueryUsersCollectionByEmailAddress(emailAddress)
                .FirstOrDefault();

            return MapEntityToUser(entity);
        }

        public async Task<User> GetUserByEmailAddressAsync(string emailAddress)
        {
            var entity = await QueryUsersCollectionByEmailAddress(emailAddress)
                .FirstOrDefaultAsync();

            return MapEntityToUser(entity);
        }

        private IQueryable<Entities.User> QueryUsersCollectionByEmailAddress(string emailAddress)
        {
            return DbContext.Users.Where(u => u.EmailAddress.Equals(emailAddress));
        }

        private User MapEntityToUser(Entities.User entity)
        {
            if (entity == null)
                throw new DataNotFoundException();

            return Mapper.Current.Map<User>(entity);
        }

        public User GetUserById(long userId)
        {
            var entity = DbContext.Users.FirstOrDefault(u => u.Id.Equals(userId));
            return MapEntityToUser(entity);
        }

        public ForgotPasswordToken GetForgotPasswordTokenByToken(string token)
        {
            var entity = QueryForgotPasswordTokensCollectionByToken(token).FirstOrDefault();
            return MapEntityToForgotPasswordToken(entity);
        }

        private IQueryable<Entities.ForgotPasswordToken> QueryForgotPasswordTokensCollectionByToken(string token)
        {
            return DbContext.ForgotPasswordTokens.Where(u => u.Token.Equals(token));
        }

        private ForgotPasswordToken MapEntityToForgotPasswordToken(Entities.ForgotPasswordToken entity)
        {
            if (entity == null)
                throw new DataNotFoundException();

            return Mapper.Current.Map<ForgotPasswordToken>(entity);
        }
    }
}