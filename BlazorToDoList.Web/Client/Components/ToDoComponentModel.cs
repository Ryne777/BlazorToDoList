using BlazorToDoList.Bl.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorToDoList.Web.Client.Components
{
    public class ToDoComponentModel : ComponentBase
    {
        [Parameter]
        public IndexToDoViewModel ToDo { get; set; }
    }
}
