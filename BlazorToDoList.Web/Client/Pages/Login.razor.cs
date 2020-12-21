using IdentityModel.Client;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorToDoList.Web.Client.Pages
{
    public partial class Login
    {
        [Inject]
        private IHttpClientFactory HttpClientFactory { get; set; }        
        private HttpClient HttpClient => HttpClientFactory.CreateClient("ServerAuth");
        LoginModel myModel = new LoginModel();
        public class LoginModel
        {
            [Required]
            public string Username { get; set; }

            [Required]
            [MinLength(8)]
            public string Password { get; set; }

            public string ReturnUrl => "https://localhost:5001/authentication/login-callback";
        }
        void Reset()
        {
            myModel.Username = null;
            myModel.Password = null;
        }
        async Task Success()
        {
            var doc = await HttpClient.GetDiscoveryDocumentAsync("https://localhost:10001");
            Console.WriteLine(doc.AuthorizeEndpoint);
            var uri = new RequestUrl(doc.AuthorizeEndpoint);
            var query = uri.CreateAuthorizeUrl(
                clientId: "client_blazor_web_assembly",
                redirectUri: "https://localhost:5001/authentication/login-callback",
                responseType: "code",
                responseMode: "query",
                scope: "openid profile blazor",
                state: "abc &"
                );
            var cod = await HttpClient.GetAsync(query);
            Console.WriteLine(cod);
            
            var response = await HttpClient.RequestAuthorizationCodeTokenAsync(new AuthorizationCodeTokenRequest
            {
                Address = doc.TokenEndpoint,

                ClientId = "client_blazor_web_assembly",
                

                Code = "code",
                RedirectUri = myModel.ReturnUrl,

                // optional PKCE parameter
                //CodeVerifier = "xyz"
            });
        }
        


    }
}
