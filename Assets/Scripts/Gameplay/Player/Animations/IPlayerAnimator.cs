using UnityEngine;

namespace Gameplay.Player.Animations
{
    public interface IPlayerAnimator
    {
        public void Update(Transform playerObject);
    }
}