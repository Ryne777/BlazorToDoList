using BlazorToDoList.Bl.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BlazorToDoList.Web.Client.Components
{
    public class ToDoListComponentModel : ComponentBase
    {

        [Parameter]
        public EventCallback<string> Delete { get; set; }
        [Parameter]
        public EventCallback<UpdateToDoViewModel> UpdateEvent { get; set; }
        [Parameter]
        public IEnumerable<IndexToDoViewModel> ToDoList { get; set; }

        protected void DeleteFromList(IndexToDoViewModel item)
        {
            Delete.InvokeAsync(item.Id);
            ToDoList = ToDoList.Where(x => x != item);            
        }
        protected void Update(UpdateToDoViewModel item)
        {
            UpdateEvent.InvokeAsync(item);            
        }

    }
}
