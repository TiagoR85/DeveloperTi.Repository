namespace DeveloperTi.UnityOfWork
{
    public interface IUnityOfWork
    {
        void Commit();
        void RollBack();
    }
}