using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QuickTimeEvent
{
    public class QuickTimeEventUI : MonoBehaviour
    {
        [SerializeField] private GameObject _quickTimePrefab;
        [SerializeField] private float _spawnDistance = 200;

        [SerializeField] private float _diameter = 1000;
        [SerializeField] private float _rotationDistance = 15;

        // Previous 5 quick time positions
        private List<float> _previousRotations = new List<float>();


        // Replace string with matching enum
        public void CreateQuickTimeDisplay(QuickTimeInputKey type, float lifeSpan)
        {
            Debug.Log($"Spawned {type}");
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

            string txt;

            // set text
            switch (type)
            {
                case QuickTimeInputKey.NORTH:
                    txt = "N";
                    break;
                case QuickTimeInputKey.EAST:
                    txt = "E";
                    break;
                case QuickTimeInputKey.SOUTH:
                    txt = "S";
                    break;
                case QuickTimeInputKey.WEST:
                    txt = "W";
                    break;
                default:
                    txt = "404 LOLZ";
                    break;
            }

            rect.Find("Text").GetComponent<Text>().text = txt;

        }

        private Vector2 FindNewPosition()
        {
            Vector2 res = new Vector2();
            float rotation = 0;

            // try 15 times
            for(int i = 0; i < 15; ++i)
            {
                bool canSpawn = true;

                rotation = Random.Range(0, 360);
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

    }
}


