using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer
{
    public sealed class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("ServiceA", "ServiceA API"),
                new ApiResource("ServiceB", "ServiceB API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "ServiceAClient",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("ServiceAClient".Sha256())
                    },
                    AllowedScopes = new List<string> {"ServiceA"},
                    AccessTokenLifetime = 60 * 60 * 1
                },
                new Client
                {
                    ClientId = "ServiceBClient",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("ServiceBClient".Sha256())
                    },
                    AllowedScopes = new List<string> {"ServiceB"},
                    AccessTokenLifetime = 60 * 60 * 1
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    Username = "test",
                    Password = "123456",
                    SubjectId = "1"
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>();
        }
    }
}