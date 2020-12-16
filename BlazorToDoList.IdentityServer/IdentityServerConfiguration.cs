using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorToDoList.IdentityServer
{
    public class IdentityServerConfiguration
    {
        internal static IEnumerable<ApiResource> GetApiResources()
        {
            yield return new ApiResource("SwaggerAPI");
        }

        internal static IEnumerable<ApiScope> GetApiScopes()
        {
            yield return new ApiScope("SwaggerAPI", "Swagger API");
            yield return new ApiScope("blazor", "Blazor WebAssembly");
        }

        internal static IEnumerable<IdentityResource> GetIdentityResources()
        {
            yield return new IdentityResources.OpenId();
            yield return new IdentityResources.Profile();
            yield return new IdentityResources.Address();
            yield return new IdentityResources.Email();
        }

        internal static IEnumerable<Client> GetClients() =>
        new List<Client>
        {
            new Client
            {
                ClientId = "client_blazor_web_assembly",
                RequireClientSecret = false,
                //ClientSecrets = {new Secret("blazor_client_secrets".Sha256()) },
                RequireConsent = false,
                RequirePkce = true,
                AllowedGrantTypes =  GrantTypes.Code,
                AllowedCorsOrigins = { "https://localhost:5001" },
                PostLogoutRedirectUris = { "https://localhost:5001/authentication/logout-callback" },
                RedirectUris = { "https://localhost:5001/authentication/login-callback" },
                AllowedScopes =
                {
                    "blazor",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Address,
                    IdentityServerConstants.StandardScopes.Email
                }
            }
        };

    }
}
