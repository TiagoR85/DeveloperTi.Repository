using Microsoft.EntityFrameworkCore;

namespace DeveloperTi.UnityOfWork.EntityFramework
{
    public class UnityOfWork : DbContext, IUnityOfWork
    {
        private readonly DbContext context;

        public UnityOfWork(DbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.SaveChangesAsync();
        }

        public void RollBack() { }
    }
}
