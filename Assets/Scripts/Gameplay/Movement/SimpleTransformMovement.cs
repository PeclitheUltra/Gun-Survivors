using Gameplay.Settings;
using Gameplay.Stats;
using UnityEngine;

namespace Gameplay.Movement
{
    public class SimpleTransformMovement : IMovement
    {
        public void Move(Transform transform, Vector3 direction, float movementSpeed)
        {
            direction.Normalize();
            direction *= Time.deltaTime * movementSpeed;
            transform.position += direction;
        }

        public void RotateOverTime(Transform transform, Quaternion lookRotation, float time)
        {
            
        }
    }
}