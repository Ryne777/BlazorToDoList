using BlazorToDoList.Bl.ViewModels;
using BlazorToDoList.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorToDoList.Bl.Interfaces
{
    public interface IToDoService
    {
        Task CreateToDo(CreateTodoViewModel item);

        Task DeleteToDo(string id);

        Task<IEnumerable<IndexToDoViewModel>> GetAll();

        Task<IndexToDoViewModel> GetOneToDoById(string id);

        Task UpdateToDo(UpdateTodoViewModel item);
    }
}
