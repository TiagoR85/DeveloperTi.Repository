using Microsoft.EntityFrameworkCore;

namespace DeveloperTi.DataContext.EntityFramework
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
