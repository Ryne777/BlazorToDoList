using BlazorToDoList.Bl.Interfaces;
using BlazorToDoList.Bl.ViewModels;
using BlazorToDoList.Data.Interfaces;
using BlazorToDoList.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorToDoList.Bl.Services
{
    public class ToDoService : IToDoService
    {
        private IUnitOfWork _uow;

        public ToDoService(IUnitOfWork uow)
        {
            _uow = uow;

        }

        public async Task CreateToDo(CreateTodoViewModel item)
        {
            await _uow.GetRepository<ToDo>().Create(new ToDo
            {
                Id = Guid.NewGuid(),
                Description = item.Description,
                Status = (Status)Enum.Parse(typeof(Status), item.Status)
            });
        }

        public async Task DeleteToDo(string id)
        {
            await _uow.GetRepository<ToDo>().Delete(Guid.Parse(id));
        }

        public async Task<IEnumerable<IndexToDoViewModel>> GetAll()
        {
            var res = await _uow.GetRepository<ToDo>().GetAll();
            var result = new List<IndexToDoViewModel>();
            foreach (var item in res)
            {
                result.Add(new IndexToDoViewModel
                {
                    Description = item.Description,
                    Status = item.Status.ToString()
                });
                
            }
            return result;
        }

        public async Task<IndexToDoViewModel> GetOneToDoById(string id)
        {
            var res =  await _uow.GetRepository<ToDo>().Get(Guid.Parse(id));
            return new IndexToDoViewModel()
            {
                Description = res.Description,
                Status = res.Status.ToString()
            };
        }

        public async Task UpdateToDo(UpdateTodoViewModel item)
        {
            var repos = _uow.GetRepository<ToDo>();
            var toDo = await repos.Get(Guid.Parse(item.Id));
            repos.Update(new ToDo
            {
                Id = toDo.Id,
                Description = toDo.Description,
                Status = (Status)Enum.Parse(typeof(Status), item.Status)
            });
        }
    }
}
