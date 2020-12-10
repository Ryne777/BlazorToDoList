using BlazorToDoList.Bl.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorToDoList.Bl.Interfaces
{
    public interface IToDoService
    {
        Task CreateToDo(CreateToDoViewModel item);

        Task DeleteToDo(string id);

        Task<IEnumerable<IndexToDoViewModel>> GetAll();

        Task<IndexToDoViewModel> GetOneToDoById(string id);

        Task UpdateToDo(string id, UpdateToDoViewModel item);
    }
}
