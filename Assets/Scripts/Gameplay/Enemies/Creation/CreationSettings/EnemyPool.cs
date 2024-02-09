using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Enemies.Creation.CreationSettings
{
    [CreateAssetMenu(fileName = "Enemy Pool", menuName = "Enemy Pool", order = 0)]
    public class EnemyPool : ScriptableObject, IEnemyPool
    {
        [field: SerializeField] public EnemySettings[] Enemies { get; private set; }
            
        public IEnemySettings GetRandom()
        {
            return Enemies[Random.Range(0, Enemies.Length)];
        }
    }
}