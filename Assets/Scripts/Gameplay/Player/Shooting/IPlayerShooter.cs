using UnityEngine;

namespace Gameplay.Player.Shooting
{
    public interface IPlayerShooter
    {
        public void UpdateAndTryToShoot(Vector3 checkOrigin);
    }
}