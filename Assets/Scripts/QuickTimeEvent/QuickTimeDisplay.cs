﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Controls;
using System;

namespace QuickTimeEvent
{
    public class QuickTimeDisplay : MonoBehaviour
    {
        [SerializeField] public float _endScale;
        private float _originalScale;
        private float _lifeSpan;
        private bool _active = false;
        
        private RectTransform _rect;
        private Image _img;


        private QuickTimeEventManager _quickTime;
        private CustomUtilities.Timer _timer;
        
        private InputManager _input;
        private void Awake()
        {
            _input = FindObjectOfType<InputManager>();
            _rect = GetComponent<RectTransform>();
            _originalScale = _rect.localScale.x;
            _quickTime = FindObjectOfType<QuickTimeEventManager>();
            _img = GetComponent<Image>();
            _input.QuickTimeInput += Interact;
        }

        private void Interact(QuickTimeInputKey obj)
        {
            _input.QuickTimeInput -= this.Interact;

            if (_quickTime.CheckInteraction(obj))
            {
                _img.color = Color.green;
            }
            else
            {
                _img.color = Color.red;
            }
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
