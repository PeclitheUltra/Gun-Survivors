using UnityEngine;

namespace Gameplay.FX.PlayerShootFX
{
    public interface IOnShootFX
    {
        public void PlayOnShoot(Vector3 startPos, Vector3 endPos);
    }
}
