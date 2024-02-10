using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Gameplay.FX.PlayerShootFX
{
    public class GunTrailFX : MonoBehaviour, IOnShootFX
    {
        [SerializeField] private List<LineRenderer> _lines;
        private int _currentLine;
        private static readonly int AlphaTint = Shader.PropertyToID("_AlphaTint");

        public void PlayOnShoot(Vector3 startPos, Vector3 endPos)
        {
            _lines[_currentLine].material.DOKill();
            _lines[_currentLine].positionCount = 2;
            _lines[_currentLine].SetPosition(0, startPos);
            _lines[_currentLine].SetPosition(1, endPos);
            _lines[_currentLine].material.SetFloat(AlphaTint, 1);
            _lines[_currentLine].material.DOFloat(0, AlphaTint, .3f);
            _currentLine = (int)Mathf.Repeat(_currentLine + 1, _lines.Count);
        }
    }
}