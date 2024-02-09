using Gameplay.Stats;
using UnityEngine;

namespace Gameplay.Settings
{
    [CreateAssetMenu(fileName = "Player Settings", menuName = "Player Settings", order = 0)]
    public class PlayerSettings : ScriptableObject, IStats, IPlayerAttackSettings
    {
        [field: SerializeField] public float Health { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public float AttackTime { get; private set; }
        [field: SerializeField] public float AttackRange { get; private set; }
        [field: SerializeField] public float AttackDamage { get; private set; }
        [field: SerializeField] public LayerMask AttackMask { get; private set; }
    }
}
