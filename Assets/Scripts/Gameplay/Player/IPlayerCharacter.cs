using System;
using UnityEngine;

namespace Gameplay.Player
{
    public interface IPlayerCharacter
    {
        public event Action Death;
        public Vector3 Position { get; }
        public void DealDamage(float damage);
    }
}