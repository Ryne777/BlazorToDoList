using BlazorToDoList.Bl.ViewModels;
using BlazorToDoList.Data.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorToDoList.Web.Client.Components
{
    public class CreateToDoComponentModel : ComponentBase
    {
        protected bool dialogIsOpen = false;
        public CreateToDoViewModel Item { get; set; }        
        public string Description { get; set; }
        [Parameter]
        public EventCallback<CreateToDoViewModel> NewToDo { get; set; }

        public string StatusValue { get; set; }

        protected void OpenDialog()
        {
            Description = null;
            StatusValue = null;
            dialogIsOpen = true;
        }

        protected void OkClick()
        {
            dialogIsOpen = false;
            if (Description != null && StatusValue != null)
            {
                Item = new()
                {
                    Description = Description,
                    Status = (Status)Enum.Parse(typeof(Status), StatusValue)
                };
                NewToDo.InvokeAsync(Item);
                
            }
        }
    }
}
