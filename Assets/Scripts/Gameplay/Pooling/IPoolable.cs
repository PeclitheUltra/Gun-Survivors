namespace Gameplay.Pooling
{
    public interface IPoolable
    {
        public void OnGetFromPool();
        public void OnReturnToPool();
    }
}