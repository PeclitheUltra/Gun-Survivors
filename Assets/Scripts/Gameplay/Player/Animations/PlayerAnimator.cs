using UnityEngine;

namespace Gameplay.Player.Animations
{
    public class PlayerAnimator : IPlayerAnimator
    {
        private bool _foundAnimator;
        private Animator _animator;
        private Vector3 _lastFramePosition;
        private Vector3 _velocity;
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");

        public void Update(Transform playerObject)
        {
            if (!_foundAnimator)
            {
                _animator = playerObject.GetComponentInChildren<Animator>();
                _foundAnimator = _animator != null;
                return;
            }

            _velocity = (playerObject.position - _lastFramePosition) / Time.deltaTime;


            _animator.SetBool(IsRunning, _velocity.sqrMagnitude > .5f);

            
            _lastFramePosition = playerObject.position;

        }
    }
}