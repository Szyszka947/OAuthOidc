using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAuthOidc.Data.ApiResources
{
    [Table("ApiResourceClaims")]
    public class ApiResourceClaim : Claim
    {
    }
}
