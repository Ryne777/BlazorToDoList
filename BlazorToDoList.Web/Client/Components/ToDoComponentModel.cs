using BlazorToDoList.Bl.ViewModels;
using BlazorToDoList.Data.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorToDoList.Web.Client.Components
{
    public class ToDoComponentModel : ComponentBase
    {
        [Inject]
        HttpClient Http { get; set; }
        [Parameter]
        public IndexToDoViewModel ToDo { get; set; }
        [Parameter]
        public EventCallback<IndexToDoViewModel> DeleteEvent { get; set; }
        [Parameter]
        public EventCallback<UpdateToDoViewModel> UpdateEvent { get; set; }

        public UpdateToDoViewModel SaveToDo { get; set; }
        protected  string StatusValue { get; set; }
        protected bool dialogIsOpen = false;

        protected void OpenDialog()
        {
            
            StatusValue = ToDo.Status.ToString();
            dialogIsOpen = true;
        }

        protected void OkClick()
        {
            dialogIsOpen = false;
            if (StatusValue != null)
            {
                SaveToDo = new()
                {
                    Id = ToDo.Id,
                    Status = (Status)Enum.Parse(typeof(Status), StatusValue)
                };
                UpdateEvent.InvokeAsync(SaveToDo);
            }
        }

    }
}
