using UnityEngine;

namespace Gameplay.Player
{
    public interface IPlayerCharacter
    {
        public Vector3 Position { get; }
        public void DealDamage(float damage);
    }
}