using DeveloperTi.DataContext.EntityFramework;

namespace DeveloperTi.UnityOfWork.EntityFramework
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly IDataContext context;

        public UnityOfWork(IDataContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.CommitAsync();
        }

        public void RollBack() { }
    }
}
