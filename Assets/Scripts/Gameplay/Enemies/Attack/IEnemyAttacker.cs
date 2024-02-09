using Gameplay.Player;
using Gameplay.Stats;
using UnityEngine;

namespace Gameplay.Enemies.Attack
{
    public interface IEnemyAttacker
    {
        public void TryAttack(Vector3 myPosition, IPlayerCharacter playerCharacter, IStats stats);
    }
}
