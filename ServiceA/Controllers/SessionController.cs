using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        public async Task<string> Login(UserRequestModel userRequestModel)
        {
            // discover endpoints from metadata
            var client = new HttpClient();
            DiscoveryResponse disco = await client.GetDiscoveryDocumentAsync("http://localhost:38033");
            if (disco.IsError)
            {
                return "认证服务器未启动";
            }
            TokenResponse tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "ServiceAClient",
                ClientSecret = "ServiceAClient"
            });

            return tokenResponse.IsError ? tokenResponse.Error : tokenResponse.AccessToken;

        }
    }

    public class UserRequestModel
    {
        [Required(ErrorMessage = "用户名称不可以为空")]
        public string Name { get; set; }

        [Required(ErrorMessage = "用户密码不可以为空")]
        public string Password { get; set; }
    }
}