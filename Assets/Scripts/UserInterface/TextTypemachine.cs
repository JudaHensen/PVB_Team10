using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class TextTypemachine : MonoBehaviour
    {
        private Text _text;

        private CustomUtilities.Timer _timer;
        private float _typeSpeed;
        private char[] _message;

        private bool _isTyping;

        private void Start()
        {
            _text = GetComponent<Text>();
        }

        public void TypeMessage(string message, float typeSpeed)
        {
            Clear();
            _typeSpeed = typeSpeed;
            _message = message.ToCharArray();

            _timer = new CustomUtilities.Timer(_typeSpeed * _message.Length);
            _isTyping = true;
        }

        public void Clear()
        {
            _text.text = "";
            _timer = null;
            _message = null;
            _isTyping = false;
        }

        private void Update()
        {
            if(_isTyping)
            {
                int charactersToType;
                string characters = "";

                _timer.Update();

                charactersToType = (int)Mathf.Floor(_timer.GetTime() / _typeSpeed);
                if (charactersToType > _message.Length)
                {
                    charactersToType = _message.Length;
                    _isTyping = false;
                }
                    

                for (int i = 0; i < charactersToType; ++i)
                {
                    characters += _message[i];
                }

                _text.text = characters;
            }
            
        }

    }
}

