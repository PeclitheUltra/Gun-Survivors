using System;
using DG.Tweening;
using UnityEngine;

namespace Gameplay.UI.Displays
{
    public class DoubleSpriteWithDelay : MonoBehaviour, INormalizedDisplay
    {
        [SerializeField] private SpriteRenderer _mainSr, _delayedSr;
        private float _defaultWidth;
        
        private void Start()
        {
            _defaultWidth = _mainSr.size.x;
        }

        public void SetValue(float normalizedValue)
        {
            _delayedSr.DOKill();
            var targetWidth = Mathf.Lerp(0, _defaultWidth, normalizedValue);
            _mainSr.size = new Vector2(targetWidth, _mainSr.size.y);
            DOTween.To(x => _delayedSr.size = new Vector2(x, _delayedSr.size.y),
                _delayedSr.size.x, targetWidth, .3f).SetTarget(_delayedSr);
        }
    }
}
