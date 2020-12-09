using BlazorToDoList.Bl.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorToDoList.Web.Client.Pages
{
    public class IndexModel:ComponentBase
    {
        [Inject]
        private HttpClient  HttpClient { get; set; }
        protected IEnumerable<IndexToDoViewModel> toDoList;
        public IndexToDoViewModel ToDo { get; set; }

        protected override async Task OnInitializedAsync()
        {   
            toDoList = await HttpClient.GetFromJsonAsync<IEnumerable<IndexToDoViewModel>>("api/ToDo");
            ToDo = toDoList.FirstOrDefault();
        }

                  
            //base.OnInitialized();
        
    }
}
