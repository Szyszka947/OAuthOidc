using System.ComponentModel.DataAnnotations.Schema;

namespace OAuthOidc.Data.ApiResources
{
    [Table("ApiResourceSecrets")]
    public class ApiResourceSecret : Secret
    {
    }
}
