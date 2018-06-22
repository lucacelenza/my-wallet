using AutoMapper;
using CLSoft.MyWallet.Data.EntityFramework.Configuration;
using CLSoft.MyWallet.Data.Exceptions;
using CLSoft.MyWallet.Data.Models.Wallets;
using CLSoft.MyWallet.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Data.EntityFramework.Repositories
{
    public class EntityFrameworkWalletsRepository : EntityFrameworkRepository, IWalletsRepository
    {
        private readonly IMapper _mapper;

        public EntityFrameworkWalletsRepository(MyWalletDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task AddWalletAsync(AddWalletRequest request)
        {
            var entity = _mapper.Map<Entities.Wallet>(request);
            DbContext.Wallets.Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteWalletByIdAsync(long walletId)
        {
            var entity = await GetWalletEntityByIdAsync(walletId);
            DbContext.Wallets.Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task EditWalletAsync(EditWalletRequest request)
        {
            var entity = await GetWalletEntityByIdAsync(request.WalletId);

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.LastUpdatedOn = request.UpdatedOn;

            await DbContext.SaveChangesAsync();
        }

        public async Task<Wallets> GetAllWalletsByUserIdAsync(long userId)
        {
            var entities = await DbContext.Wallets
                .Where(w => w.UserId.Equals(userId)).ToArrayAsync();

            return _mapper.Map<Wallets>(entities);
        }

        public async Task<Wallet> GetWalletByIdAsync(long walletId)
        {
            var entity = await GetWalletEntityByIdAsync(walletId);
            return _mapper.Map<Wallet>(entity);
        }

        private async Task<Entities.Wallet> GetWalletEntityByIdAsync(long walletId)
        {
            var entity = await DbContext.Wallets
                .FirstOrDefaultAsync(t => t.Id.Equals(walletId));

            if (entity == null)
                throw new DataNotFoundException();

            return entity;
        }
    }
}