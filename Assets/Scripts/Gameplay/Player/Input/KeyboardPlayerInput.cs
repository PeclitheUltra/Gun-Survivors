using UnityEngine;

namespace Gameplay.Player.Input
{
    public class KeyboardPlayerInput : IPlayerInput
    {
        public Vector2 InputDirection => new Vector2(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"));
    }
}