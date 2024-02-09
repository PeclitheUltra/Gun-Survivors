namespace Gameplay.Enemies.Creation.CreationSettings
{
    public interface IEnemyPool
    {
        public IEnemySettings GetRandom();
    }
}