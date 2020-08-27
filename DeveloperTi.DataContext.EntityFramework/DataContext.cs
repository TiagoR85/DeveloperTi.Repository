using Microsoft.EntityFrameworkCore;

namespace DeveloperTi.DataContext.EntityFramework
{
    public class DataContext : DbContext, IDataContext
    {
        private readonly DbContext context;

        public DataContext(DbContext context)
        {
            this.context = context;
        }
        //public DbSet<TEntity> Tabelas { get; set; }
        public void CommitAsync()
        {
            context.SaveChangesAsync();
        }
    }
}
