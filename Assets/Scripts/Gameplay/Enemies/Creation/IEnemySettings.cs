using Gameplay.Stats;
using UnityEngine;

namespace Gameplay.Enemies.Creation
{
    public interface IEnemySettings : IStats
    {
        public GameObject Graphics { get; }
    }
}
