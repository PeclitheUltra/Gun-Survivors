using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI.Displays
{
    public class DoubleSliderWithDelay : MonoBehaviour, INormalizedDisplay
    {
        [SerializeField] private Slider _sliderMain, _sliderDelayed;
        
        public void SetValue(float normalizedValue)
        {
            _sliderMain.value = normalizedValue;
            _sliderDelayed.DOKill();
            _sliderDelayed.DOValue(normalizedValue, .4f);
        }
    }
}
