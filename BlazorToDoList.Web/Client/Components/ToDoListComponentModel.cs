using BlazorToDoList.Bl.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorToDoList.Web.Client.Components
{
    public class ToDoListComponentModel:ComponentBase
    {
        [Parameter]
        public IEnumerable<IndexToDoViewModel> ToDoList { get; set; }
    }
}
