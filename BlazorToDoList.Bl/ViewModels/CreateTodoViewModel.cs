using BlazorToDoList.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorToDoList.Bl.ViewModels
{
    public class CreateTodoViewModel:IValidatableObject
    {
        [Required]
        [MinLength(3,ErrorMessage ="min length 3")]
        public string Description { get; set; }
        [Required]
        [EnumDataType(typeof(Status))]        
        public Status Status { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           if(Status == Status.None)
            {
                yield return new ValidationResult("Status not select");
            }
        }
    }
}
