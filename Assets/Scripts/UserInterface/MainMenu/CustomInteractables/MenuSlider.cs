using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class MenuSlider : MenuInteractable
    {
        [SerializeField]
        [Header("Name to save value in playerprefs")]
        private string _valueName;

        [SerializeField]
        private float _defaultValue;

        [SerializeField]
        private float _valueIncrease;

        private float _currentValue;
        private Slider _slider;

        protected override void Awake()
        {
            base.Awake();

            if (PlayerPrefs.HasKey(_valueName)) _currentValue = PlayerPrefs.GetFloat(_valueName);
            else _currentValue = _defaultValue;

            _slider = transform.Find("Slider").gameObject.GetComponent<Slider>();
            _slider.value = _currentValue;
        }

        public override void Left()
        {
            base.Left();
            _currentValue -= _valueIncrease;

            if (_currentValue <= _slider.minValue) _currentValue = _slider.minValue;
            _slider.value = _currentValue;

            PlayerPrefs.SetFloat(_valueName, _currentValue);
            PlayerPrefs.Save();
        }

        public override void Right()
        {
            base.Right();
            _currentValue += _valueIncrease;

            if (_currentValue >= _slider.maxValue) _currentValue = _slider.maxValue;
            _slider.value = _currentValue;

            PlayerPrefs.SetFloat(_valueName, _currentValue);
            PlayerPrefs.Save();
        }

    }
}

