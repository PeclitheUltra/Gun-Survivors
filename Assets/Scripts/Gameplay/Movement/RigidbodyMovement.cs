using UnityEngine;

namespace Gameplay.Movement
{
    public class RigidbodyMovement : IMovement
    {
        private bool _foundRigidbody;
        private Rigidbody _rigidbody;
        
        public void Move(Transform transform, Vector3 direction, float movementSpeed)
        {
            if (!_foundRigidbody)
            {
                _foundRigidbody = transform.TryGetComponent<Rigidbody>(out _rigidbody);
                return;
            }
            direction.Normalize();
            _rigidbody.velocity = direction * movementSpeed;

        }
    }
}