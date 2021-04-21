using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuickTimeEvent
{
    public class QuickTimeDisplay : MonoBehaviour
    {
        [SerializeField] public float _endScale;
        private float _lifeSpan;
        private bool _active = false;
        private CustomUtilities.Timer _timer;
        private RectTransform _rect;
        private float _originalScale;

        private void Awake()
        {
            _rect = GetComponent<RectTransform>();
            _originalScale = _rect.localScale.x;
        }

        private void Update()
        {
            if (_active)
            {
                // calculates and alters the scale of the rectTransform.
                _timer.Update();
                float percentage, scale;
                percentage = _timer.GetTime() / _lifeSpan;

                if (_timer.Completed() )
                {
                    percentage = 1;
                    Destroy(gameObject);
                }

                scale = (_endScale - _originalScale) * percentage + _originalScale;
                _rect.localScale = new Vector3(scale, scale, 1);
            }
        }

        // needs to be calles after creating prefab.
        public void SetActive(float lifeSpan)
        {
            _lifeSpan = lifeSpan;
            _active = true;
            _timer = new CustomUtilities.Timer(_lifeSpan);
        }

    }

}

