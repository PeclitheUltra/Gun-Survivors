using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Gameplay.UI.Screens
{
    public class FinishScreen : MonoBehaviour, IFinishScreen
    {
        [SerializeField] private CanvasGroup _background, _label;
        
        public void Show(Action animationEndedCallback)
        {
            PlayAppearAnimation(animationEndedCallback).Forget();
        }

        private async UniTaskVoid PlayAppearAnimation(Action animationEndedCallback)
        {
            gameObject.SetActive(true);
            _background.alpha = 0;
            _label.alpha = 0;
            _background.DOFade(1, .4f).SetUpdate(true);
            await UniTask.WaitForSeconds(.5f, true);
            _label.transform.localScale = Vector3.one * .8f;
            _label.transform.DOScale(1, .4f).SetUpdate(true);
            _label.DOFade(1, .4f).SetUpdate(true);
            await UniTask.WaitForSeconds(1f, true);
            animationEndedCallback?.Invoke();
        }
    }
}