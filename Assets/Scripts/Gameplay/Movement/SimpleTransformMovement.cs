using Gameplay.Settings;
using Gameplay.Stats;
using UnityEngine;

namespace Gameplay.Movement
{
    public class SimpleTransformMovement : IMovement
    {
        private IStats _stats;

        public SimpleTransformMovement(IStats stats)
        {
            _stats = stats;
        }

        public void Move(Transform transform, Vector3 direction)
        {
            direction.Normalize();
            direction *= Time.deltaTime * _stats.MovementSpeed;
            transform.position += direction;
        }
    }
}