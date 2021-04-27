using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ChunkSystem
{

    public class ChunkSystem : MonoBehaviour
    {
        [SerializeField]
        private float _planeBounds = 75f;

        [SerializeField]
        private GameObject _chunkPerfab;

        private Transform _ship;
        private Vector2 _currentPosition;

        void Start()
        {
            // get ship
            _ship = GameObject.Find("MineHunter").GetComponent<Transform>();

            _currentPosition = new Vector2();
            _currentPosition.x = Mathf.RoundToInt(_ship.position.x / 100) * 100;
            _currentPosition.y = Mathf.RoundToInt(_ship.position.z / 100) * 100;
        }

        void Update()
        {
            // get ship position
            Vector2 pos = new Vector2(_ship.position.x, _ship.position.z);

            // if out of bounds
            if (OutOfBounds(pos))
            {
                // move planes
                MoveSurface(pos);

                // generate mines

                // unload mines

            }
        }

        private void MoveSurface(Vector2 refPos)
        {
            _currentPosition = GetNewPosition(refPos);
            transform.position = new Vector3(refPos.x, 0, refPos.y);
        }

        private Vector2 GetNewPosition(Vector2 refPos)
        {
            Vector2 pos = new Vector2(_currentPosition.x, _currentPosition.y);

            if (refPos.x >= _currentPosition.x + _planeBounds) pos.x += 100;
            if (refPos.x <= _currentPosition.x - _planeBounds) pos.x -= 100;
            if (refPos.y >= _currentPosition.y + _planeBounds) pos.y += 100;
            if (refPos.y <= _currentPosition.y - _planeBounds) pos.y -= 100;

            return pos;
        }

        private bool OutOfBounds(Vector2 refPos)
        {
            if (refPos.x >= _currentPosition.x + _planeBounds) return true;
            if (refPos.x <= _currentPosition.x - _planeBounds) return true;
            if (refPos.y >= _currentPosition.y + _planeBounds) return true;
            if (refPos.y <= _currentPosition.y - _planeBounds) return true;

            return false;
        }

    }
}