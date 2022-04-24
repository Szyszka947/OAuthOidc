using System.ComponentModel.DataAnnotations.Schema;

namespace OAuthOidc.Data.Clients
{
    [Table("ClientSecrets")]
    public class ClientSecret : Secret
    {
    }
}
