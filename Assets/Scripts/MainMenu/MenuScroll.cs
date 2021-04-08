using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
    public class MenuScroll : MonoBehaviour
    {
        [SerializeField]
        private float _scrollSpeed;

        private float _sinRotation;
        private bool _active = false;

        private float _startPosition;
        private float _endPosition;

        private RectTransform rect;

        private void Start()
        {
            rect = GetComponent<RectTransform>();
        }

        // Determine which position to scroll to
        public void ScrollTo(float finalPosition)
        {
            _startPosition = rect.anchoredPosition.y;
            _endPosition = finalPosition;

            _sinRotation = 0;
            _active = true;
        }
        
        void Update()
        {
            if (_active) UpdateScrollPosition();
        }

        // Scrolls to the given position
        private void UpdateScrollPosition()
        {
            _sinRotation += _scrollSpeed;
            if (_sinRotation >= 90)
            {
                _active = false;
                _sinRotation = 90;

                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, _endPosition);
            }

            float newPosition = _startPosition;
            newPosition += (_endPosition - _startPosition) * Mathf.Sin(_sinRotation * Mathf.PI / 180 / 100);

            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, newPosition);
        }

    }
}

