using Microsoft.EntityFrameworkCore;
using OAuthOidc.Data.DbContexts;
using OAuthOidc.Data.Users;
using OAuthOidc.ViewModels;

namespace OAuthOidc.Stores.Impl
{
    public class UserStoreImpl : IUserStore
    {
        private readonly UsersDbContext _usersDbContext;

        public UserStoreImpl(UsersDbContext dbContext)
        {
            _usersDbContext = dbContext;
        }

        public async Task<User> FindByEmailAsync(string email)
            => await _usersDbContext.Users.Include(p => p.Claims).SingleOrDefaultAsync(p => p.Email == email);

        public async Task<User> CreateAsync(SignOnViewModel signOnViewModel)
        {
            var userToCreate = new User { Email = signOnViewModel.Email, PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(signOnViewModel.Password) };

            await _usersDbContext.Users.AddAsync(userToCreate);
            await _usersDbContext.SaveChangesAsync();

            return userToCreate;
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _usersDbContext.Users.FindAsync(id);
        }
    }
}
