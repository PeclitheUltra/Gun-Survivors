namespace Sound
{
    public interface ISFXPlayer
    {
        public void PlayShoot();
        public void PlayEnemyHit();
        public void PlayPlayerHit();
        public void PlayEnemyDeath();
        public void PlayPlayerDeath();
    }
}