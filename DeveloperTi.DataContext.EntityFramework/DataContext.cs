using Microsoft.EntityFrameworkCore;

namespace DeveloperTi.DataContext.EntityFramework
{
    public class DataContext : DbContext, IDataContext
    {
        //public DbSet<TEntity> Tabelas { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
