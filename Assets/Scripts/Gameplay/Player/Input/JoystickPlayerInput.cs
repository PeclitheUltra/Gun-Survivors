using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Gameplay.Player.Input
{
    public class JoystickPlayerInput : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IPlayerInput
    {
        public Vector2 InputDirection => _input;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Transform _handle;
        private float _halfSize => _rectTransform.rect.width / 2;
        private bool _isPressed;
        private Vector2 _input;

        public void OnBeginDrag(PointerEventData eventData)
        {
            _isPressed = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 targetPos = eventData.position;
            float dist = Vector3.Distance(transform.position, targetPos);
            if (dist > _halfSize)
            {
                targetPos += (transform.position - targetPos).normalized * (dist - _halfSize);
            }
            _handle.position = Vector3.Lerp(_handle.position, targetPos, Time.deltaTime * 10f);

        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _isPressed = false;
        }

        private void Update()
        {
            if (!_isPressed)
            {
                _handle.position = Vector3.Lerp(_handle.position, transform.position, Time.deltaTime * 10f);
                _input = Vector2.zero;
            }
            else
            {
                _input = new Vector2(_handle.position.x - transform.position.x, _handle.position.y - transform.position.y) / _halfSize;
            }
        }

    }
}
