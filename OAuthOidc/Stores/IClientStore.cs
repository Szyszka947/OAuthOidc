using OAuthOidc.Data.Clients;

namespace OAuthOidc.Stores
{
    public interface IClientStore
    {
        /// <summary>
        /// Returns the client if one is found, null otherwise.
        /// </summary>
        /// <param name="clientId">The client id</param>
        /// <returns></returns>
        Task<Client> SingleByIdAsync(string clientId);
    }
}
