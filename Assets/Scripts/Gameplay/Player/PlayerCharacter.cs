using System;
using Gameplay.Movement;
using Gameplay.Player.Health;
using Gameplay.Player.Input;
using UnityEngine;
using VContainer;

namespace Gameplay.Player
{
    public class PlayerCharacter : MonoBehaviour, IPlayerCharacter
    {
        private IPlayerInput _input;
        private IMovement _movement;
        private IPlayerHealth _playerHealth;

        [Inject]
        private void Construct(IPlayerInput input, IMovement movement, IPlayerHealth playerHealth)
        {
            _playerHealth = playerHealth;
            _movement = movement;
            _input = input;
        }

        public Vector3 Position => transform.position;

        public void DealDamage(float damage)
        {
            _playerHealth.DealDamage(damage);
        }

        private void Update()
        {
            ReadInputAndMove();
        }

        private void ReadInputAndMove()
        {
            var input = _input.InputDirection;
            _movement.Move(transform, input);
        }
    }
}