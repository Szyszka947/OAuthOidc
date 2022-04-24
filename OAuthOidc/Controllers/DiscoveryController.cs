using Microsoft.AspNetCore.Mvc;
using OAuthOidc.Models;

namespace OAuthOidc.Controllers
{
    [Route(".well-known/openid-configuration")]
    [ApiController]
    public class DiscoveryController : ControllerBase
    {
        [HttpGet]
        public Discovery GetDiscovery()
        {
            return new Discovery($"{Request.Scheme}://{Request.Host}");
        }

        [HttpGet("pem")]
        public async Task<string> GetPublicKey()
        {
            return await System.IO.File.ReadAllTextAsync("rsa.public");
        }
    }
}
