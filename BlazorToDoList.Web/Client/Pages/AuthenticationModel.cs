using Microsoft.AspNetCore.Components;

namespace BlazorToDoList.Web.Client.Pages
{
    public class AuthenticationModel: ComponentBase
    {
        [Parameter] 
        public string Action { get; set; }
    }
}
