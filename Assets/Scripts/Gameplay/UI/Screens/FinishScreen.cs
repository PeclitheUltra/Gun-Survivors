﻿using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Gameplay.UI.Screens
{
    public class FinishScreen : MonoBehaviour, IFinishScreen
    {
        public event Action AnimationFinished;
        [SerializeField] private CanvasGroup _background, _label;
        
        public void Show()
        {
            PlayAppearAnimation();
        }

        private async UniTaskVoid PlayAppearAnimation()
        {
            gameObject.SetActive(true);
            _background.alpha = 0;
            _label.alpha = 0;
            _background.DOFade(1, .4f);
            await UniTask.WaitForSeconds(.5f);
            _label.transform.localScale = Vector3.one * .8f;
            _label.transform.DOScale(1, .4f);
            _label.DOFade(1, .4f);
            await UniTask.WaitForSeconds(1f);
            AnimationFinished?.Invoke();
        }
    }
}