using UnityEngine;

namespace Gameplay.Settings
{
    public interface IPlayerAttackSettings
    {
        public LayerMask AttackMask { get; }
    }
}