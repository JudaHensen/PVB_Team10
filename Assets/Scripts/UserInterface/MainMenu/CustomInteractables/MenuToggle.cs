using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class MenuToggle : MenuInteractable
    {
        [SerializeField]
        [Header("Name to save value in playerprefs")]
        private string _valueName;

        [SerializeField]
        [Header("Player prefs doesn't support bool, so we use an int, 0 = false, 1 = true")]
        private int _defaultValue;

        private int _currentValue;
        private Slider _slider;

        protected override void Start()
        {
            base.Start();

            if (PlayerPrefs.HasKey(_valueName)) _currentValue = PlayerPrefs.GetInt(_valueName);
            else _currentValue = _defaultValue;

            _slider = transform.Find("Slider").gameObject.GetComponent<Slider>();
            _slider.value = _currentValue;
        }

        public override void Left()
        {
            base.Left();
            _currentValue = 0;
            _slider.value = _currentValue;

            PlayerPrefs.SetInt(_valueName, _currentValue);
            PlayerPrefs.Save();
        }

        public override void Right()
        {
            base.Right();
            _currentValue = 1;
            _slider.value = _currentValue;

            PlayerPrefs.SetInt(_valueName, _currentValue);
            PlayerPrefs.Save();
        }

    }
}

