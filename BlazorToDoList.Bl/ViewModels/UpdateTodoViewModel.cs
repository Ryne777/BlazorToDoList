﻿using BlazorToDoList.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorToDoList.Bl.ViewModels
{
    public class UpdateTodoViewModel : IValidatableObject
    {
        public Status Status { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Status == Status.None)
            {
                yield return new ValidationResult("Status not select");
            }
        }
    }
}
