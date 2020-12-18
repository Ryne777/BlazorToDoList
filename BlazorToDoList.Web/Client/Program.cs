using MatBlazor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BlazorToDoList.Web.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            
            builder.Services.AddHttpClient("ServerAPI",
            client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
                .CreateClient("ServerAPI"));

            builder.Services.AddHttpClient("ServerAuth",
           client => client.BaseAddress = new Uri("https://localhost:10001"))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
                .CreateClient("ServerAuth"));
            builder.Services.AddMatBlazor();
            //builder.Services.AddOptions();
            //builder.Services.AddApiAuthorization();
            builder.Services.AddOidcAuthentication(options =>
            {
                // Configure your authentication provider options here.
                // For more information, see https://aka.ms/blazor-standalone-auth
                options.ProviderOptions.Authority = "https://localhost:10001";
                options.ProviderOptions.ClientId = "client_blazor_web_assembly";
                options.ProviderOptions.RedirectUri = "https://localhost:5001/authentication/login-callback";
                options.ProviderOptions.DefaultScopes.Add("openid");
                options.ProviderOptions.DefaultScopes.Add("profile");                
                options.ProviderOptions.DefaultScopes.Add("blazor");
                options.ProviderOptions.ResponseMode = "query";
                options.ProviderOptions.ResponseType = "code";
                options.UserOptions.NameClaim = "sub";
                


                builder.Configuration.Bind("oidc", options.ProviderOptions);

            });

            await builder.Build().RunAsync();
        }
    }
}
