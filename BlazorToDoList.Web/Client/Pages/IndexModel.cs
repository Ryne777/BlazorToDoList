using BlazorToDoList.Bl.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorToDoList.Web.Client.Pages
{
    public class IndexModel : ComponentBase
    {
        [Inject]
        private HttpClient HttpClient { get; set; }
        protected IEnumerable<IndexToDoViewModel> toDoList;        


        protected override async Task OnInitializedAsync()
        {
            await GetData();
        }

        private async Task GetData()
        {
            toDoList = await HttpClient.GetFromJsonAsync<IEnumerable<IndexToDoViewModel>>("api/ToDo");
        }

        protected async Task Delete(string id)
        {
            await HttpClient.DeleteAsync($"api/todo/{id}");
            await GetData();
        }


        protected async Task Create(CreateToDoViewModel createToDoViewModel)
        {
            await HttpClient.PostAsJsonAsync("api/todo", createToDoViewModel);
            await GetData();
        }
        protected async Task Update(UpdateToDoViewModel item)
        {
            await HttpClient.PutAsJsonAsync($"api/todo/{item.Id}", item);
            await GetData();
        }

    }
}
