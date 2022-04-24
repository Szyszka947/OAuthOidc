using OAuthOidc.Data.Users;
using OAuthOidc.ViewModels;

namespace OAuthOidc.Stores
{
    public interface IUserStore
    {
        Task<User> FindByEmailAsync(string email);
        Task<User> FindByIdAsync(int id);
        Task<User> CreateAsync(SignOnViewModel signOnViewModel);
    }
}
