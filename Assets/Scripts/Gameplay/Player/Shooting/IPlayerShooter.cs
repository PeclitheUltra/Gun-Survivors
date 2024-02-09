using System;
using UnityEngine;

namespace Gameplay.Player.Shooting
{
    public interface IPlayerShooter
    {
        public event Action<GameObject> ShotFired;
        public void UpdateAndTryToShoot(Vector3 checkOrigin);
    }
}