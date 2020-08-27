using Microsoft.EntityFrameworkCore;

namespace DeveloperTi.DataContext.EntityFramework
{
    public interface IDataContext
    {
        //DbSet<TEntity> Tabelas { get; set; }
        void CommitAsync();
    }
}