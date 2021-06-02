using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Controls;
using System;

namespace QuickTimeEvent
{
    public class QuickTimeEventUI : MonoBehaviour
    {
        private InputManager _input;

        [SerializeField] private GameObject _quickTimePrefab;
        [SerializeField] private float _spawnDistance = 200;

        [SerializeField] private float _diameter = 1000;
        [SerializeField] private float _rotationDistance = 15;

        // Playstation Sprites
        public Sprite ps_N;
        public Sprite ps_E;
        public Sprite ps_S;
        public Sprite ps_W;

        // Xbox Sprites
        public Sprite xb_N;
        public Sprite xb_E;
        public Sprite xb_S;
        public Sprite xb_W;

        private void Start()
        {
            _input = FindObjectOfType<InputManager>();
        }

        // Previous 5 quick time positions
        private List<float> _previousRotations = new List<float>();

        // Replace string with matching enum
        public void CreateQuickTimeDisplay(QuickTimeInputKey type, float lifeSpan)
        {
            //Debug.Log($"Spawned {type}");
            // find new position
            Vector2 pos = FindNewPosition();

            // update previous positions list
            while (_previousRotations.Count > 5)
            {
                _previousRotations.RemoveAt(0);
            }

            // instantiate
            GameObject quickTime = Instantiate(_quickTimePrefab);

            // activate scaling
            quickTime.GetComponent<QuickTimeDisplay>().SetActive(lifeSpan);

            // set position

            RectTransform rect = quickTime.GetComponent<RectTransform>();
            rect.SetParent(transform);
            rect.localPosition = pos;

            Sprite img = SetSprite(type);
            rect.GetComponent<Image>().sprite = img;

        }

        private Vector2 FindNewPosition()
        {
            Vector2 res = new Vector2();
            float rotation = 0;

            // try 15 times
            for(int i = 0; i < 15; ++i)
            {
                bool canSpawn = true;

                rotation = UnityEngine.Random.Range(0, 360);
                for(int x = 0; x < _previousRotations.Count; ++x)
                {
                    if(rotation >= _previousRotations[x]-_rotationDistance && rotation <= _previousRotations[x]+_rotationDistance)
                    {
                        canSpawn = false;
                        break;
                    }
                }

                if (canSpawn) break;
            }

            _previousRotations.Add(rotation);

            res.x = (_diameter / 2) * Mathf.Sin(rotation * Mathf.Deg2Rad);
            res.y = (_diameter / 2) * Mathf.Cos(rotation * Mathf.Deg2Rad);

            return res;
        }

        private Sprite SetSprite(QuickTimeInputKey key)
        {
            ControllerType _controllerType = _input.GetControllerType();
            //Debug.Log(_controllerType);
            // Playstation Sprites
            if(_controllerType == ControllerType.PS4)
            {
                switch (key)
                {
                    case QuickTimeInputKey.NORTH:
                        return ps_N;
                    case QuickTimeInputKey.EAST:
                        return ps_E;
                    case QuickTimeInputKey.SOUTH:
                        return ps_S;
                    case QuickTimeInputKey.WEST:
                        return ps_W;
                    default:
                        Debug.LogWarning("Wrong Key given");
                        return ps_N;
                }
            }
            // Xbox Sprites
            else
            {
                switch (key)
                {
                    case QuickTimeInputKey.NORTH:
                        return xb_N;
                    case QuickTimeInputKey.EAST:
                        return xb_E;
                    case QuickTimeInputKey.SOUTH:
                        return xb_S;
                    case QuickTimeInputKey.WEST:
                        return xb_W;
                    default:
                        Debug.LogWarning("Wrong Key given");
                        return xb_N;
                }
            }
        }

    }
}


