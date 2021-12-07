using Microsoft.EntityFrameworkCore;


namespace TemalabBackend.DAL.EF
{
    public partial class ToDoDbContext : DbContext
    {
        public ToDoDbContext()
        {
        }

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ToDoItem> ToDoItem { get; set; }

    }
}