using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class CountdownTimer : MonoBehaviour
    {
        [SerializeField]
        private float _time;
        [SerializeField]
        private bool _active;
        [SerializeField]
        private bool _visible;
        
        private GameObject _text;
        private Image _background;
        private CustomUtilities.Timer _timer;


        private void Start()
        {
            _text = transform.Find("Text").gameObject;
            _background = GetComponent<Image>();

            _timer = new CustomUtilities.Timer(_time);
            _timer.SetActive(_active);

            SetVisibility(_visible);
        }

        public void SetActive(bool value)
        {
            _active = value;
            _timer.SetActive(_active);
        }

        public void SetVisibility(bool value)
        {
            _visible = value;
            _text.SetActive(_visible);
            _background.enabled = _visible;
        }

        private void Update()
        {
            if(_active)
            {
                _timer.Update();
                _text.GetComponent<Text>().text = _timer.GetCountdown();
            }
        }

    }
}

