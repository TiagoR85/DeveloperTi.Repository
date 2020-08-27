using System.Threading.Tasks;

namespace DeveloperTi.UnityOfWork
{
    public interface IUnityOfWork
    {
        void Commit();
        Task CommitAsync();
        void RollBack();
    }
}