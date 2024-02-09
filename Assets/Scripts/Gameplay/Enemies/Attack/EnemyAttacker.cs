using Cysharp.Threading.Tasks;
using Gameplay.Player;
using Gameplay.Stats;
using UnityEngine;

namespace Gameplay.Enemies.Attack
{
    public class EnemyAttacker : IEnemyAttacker
    {
        private bool _canAttack = true;
    
        public void TryAttack(Vector3 myPosition, IPlayerCharacter playerCharacter, IStats stats)
        {
            if (!_canAttack)
                return;
            if (Vector3.SqrMagnitude(myPosition - playerCharacter.Position) < stats.AttackRange * stats.AttackRange)
            {
                playerCharacter.DealDamage(stats.AttackDamage);
                _canAttack = false;
                RechargeAttack(stats.AttackTime).Forget();
            }
        }

        private async UniTaskVoid RechargeAttack(float time)
        {
            await UniTask.WaitForSeconds(time);
            _canAttack = true;
        }
    }
}
