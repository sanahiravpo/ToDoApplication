using Microsoft.EntityFrameworkCore;
using ToDoApplication.Models;

namespace ToDoApplication.Context
{
    public class ToDoDbContext:DbContext
    {
        private readonly IConfiguration _configuration;

        public ToDoDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<ToDo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"]);
        }
    }

}

