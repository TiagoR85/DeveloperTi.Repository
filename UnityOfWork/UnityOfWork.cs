using System.Threading.Tasks;

namespace DeveloperTi.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly DataContext.EntityFramework.DataContext context;

        public UnityOfWork(DataContext.EntityFramework.DataContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        public void RollBack() { }
    }
}
