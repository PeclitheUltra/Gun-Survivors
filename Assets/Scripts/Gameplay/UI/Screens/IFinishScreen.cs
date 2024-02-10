using System;

namespace Gameplay.UI.Screens
{
    public interface IFinishScreen
    {
        public event Action AnimationFinished;
        public void Show();
    }
}