using UnityEngine;

namespace Gameplay.Movement
{
    public interface IMovement
    {
        public void Move(Transform transform, Vector3 direction, float movementSpeed);
        public void RotateOverTime(Transform transform, Quaternion lookRotation, float time);
    }
}