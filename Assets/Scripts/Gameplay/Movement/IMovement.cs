using UnityEngine;

namespace Gameplay.Movement
{
    public interface IMovement
    {
        public void Move(Transform transform, Vector3 direction);
    }
}