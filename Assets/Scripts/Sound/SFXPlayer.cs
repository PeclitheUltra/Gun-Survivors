using UnityEngine;

namespace Sound
{
    public class SFXPlayer : MonoBehaviour, ISFXPlayer
    {
        [SerializeField] private AudioSource[] _sourcesWithDifferentPitch;
        [SerializeField] private AudioClip[] _shoot, _enemyHit, _playerHit, _enemyDeath, _playerDeath;
        
        public void PlayShoot()
        {
            _sourcesWithDifferentPitch.Random().PlayOneShot(_shoot.Random());
        }

        public void PlayEnemyHit()
        {
            _sourcesWithDifferentPitch.Random().PlayOneShot(_enemyHit.Random());
        }

        public void PlayPlayerHit()
        {
            _sourcesWithDifferentPitch.Random().PlayOneShot(_playerHit.Random());
        }

        public void PlayEnemyDeath()
        {
            _sourcesWithDifferentPitch.Random().PlayOneShot(_enemyDeath.Random());
        }

        public void PlayPlayerDeath()
        {
            _sourcesWithDifferentPitch.Random().PlayOneShot(_playerDeath.Random());
        }
    }
}