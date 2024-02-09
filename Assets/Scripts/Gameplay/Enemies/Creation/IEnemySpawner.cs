namespace Gameplay.Enemies.Creation
{
    public interface IEnemySpawner
    {
        public void StartSpawning(float interval);
        public void StopSpawning();
    }
}