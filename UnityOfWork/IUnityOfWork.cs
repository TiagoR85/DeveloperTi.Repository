namespace DeveloperTi.UnityOfWork.EntityFramework
{
    public interface IUnityOfWork
    {
        void Commit();
        void RollBack();
    }
}