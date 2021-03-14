using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;


namespace CRUD
{ 
    public class TaskDbContext : DbContext
    {
        public DbSet<DbFilm> Films { get; set; }
        public DbSet<DbDirector> Directors { get; set; }
        public DbSet<DbBudget> Budgetss { get; set; }
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=FilmsDb;Trusted_Connection=True;");
            //путь);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//ищет все классы в сборке унаследшванные от интерфейса IEntityTypeConfiguration инстанцирует и устанавливает классы configuration
        }
    }
}
