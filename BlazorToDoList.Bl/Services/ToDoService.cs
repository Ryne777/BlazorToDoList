using BlazorToDoList.Bl.Interfaces;
using BlazorToDoList.Bl.ViewModels;
using BlazorToDoList.Data.Interfaces;
using BlazorToDoList.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorToDoList.Bl.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IUnitOfWork _uow;

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
                Status = item.Status
            });
            await _uow.SaveChangesAsync();
        }

        public async Task DeleteToDo(string id)
        {
            await _uow.GetRepository<ToDo>().Delete(Guid.Parse(id));
            await _uow.SaveChangesAsync();
        }

        public async Task<IEnumerable<IndexToDoViewModel>> GetAll()
        {
            var res = await _uow.GetRepository<ToDo>().GetAll();
            var result = new List<IndexToDoViewModel>();
            foreach (var item in res)
            {
                result.Add(new IndexToDoViewModel
                {
                    Id = item.Id.ToString(),
                    Description = item.Description,
                    Status = item.Status.ToString()
                });

            }
            return result;
        }

        public async Task<IndexToDoViewModel> GetOneToDoById(string id)
        {
            var res = await _uow.GetRepository<ToDo>().Get(Guid.Parse(id));
            return new IndexToDoViewModel()
            {
                Id = id,
                Description = res.Description,
                Status = res.Status.ToString()
            };
        }

        public async Task<int> UpdateToDo(string id, UpdateTodoViewModel item)
        {
            var repos = _uow.GetRepository<ToDo>();
            var toDo = await repos.Get(Guid.Parse(id));
            toDo.Status = item.Status;
            repos.Update(toDo);
            return await _uow.SaveChangesAsync();
        }
    }
}
