using UnityEngine;

namespace Gameplay.Enemies.Creation.CreationSettings
{
    [CreateAssetMenu(fileName = "Enemy Settings", menuName = "Enemy Settings", order = 0)]
    public class EnemySettings : ScriptableObject, IEnemySettings
    {
        [field: SerializeField] public GameObject Graphics { get; private set; }
        [field: SerializeField] public float Health { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public float AttackTime { get; private set; }
        [field: SerializeField] public float AttackRange { get; private set; }
        [field: SerializeField] public float AttackDamage { get; private set; }
    }
}