using UnityEngine;

namespace Gameplay.FX.PlayerShootFX
{
    public class GunShootParticle : MonoBehaviour, IOnShootFX
    {
        [SerializeField] private ParticleSystem _ps;
        public void PlayOnShoot(Vector3 startPos, Vector3 endPos)
        {
            _ps.Play();
        }
    }
}