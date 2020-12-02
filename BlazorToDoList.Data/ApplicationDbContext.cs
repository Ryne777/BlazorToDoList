using BlazorToDoList.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorToDoList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<ToDo> Todos { get; set; }
    }
}
