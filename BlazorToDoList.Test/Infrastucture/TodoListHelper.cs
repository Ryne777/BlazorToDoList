﻿using BlazorToDoList.Data.Models;
using System;
using System.Collections.Generic;

namespace BlazorToDoList.Test.Infrastucture
{
    public class TodoListHelper
    {
        public static IEnumerable<ToDo> GetMany()
        {
            yield return GetOne();
        }

        public static ToDo GetOne()
        {
            return new ToDo
            {
                Id = Guid.Parse("e5291737-bf7a-4f8f-8936-11999db20dac"),
                Description = "test description",
                Status = Status.InWork
            };
        }
    }
}