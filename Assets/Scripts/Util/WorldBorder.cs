using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameEventManagment;
namespace World
{
    public class WorldBorder : MonoBehaviour
    {
        GameEventManager _evtManager;

        // Triggers om de zones te defineren
        public Transform target;
        public float warnRange;
        public float killRange;

        private bool _isWarning = false;

        private float _range;

        private void Start()
        {
            _evtManager = FindObjectOfType<GameEventManager>();
        }

        private void FixedUpdate()
        {
            _range = Vector3.Distance(transform.position, target.position);

            if (_range >= warnRange && _range < killRange && !_isWarning)
            {
                _isWarning = true;
                GameEvent dia = new GameEvent(GameEventType.DIALOGUE, 0);
                _evtManager.RunEvent(dia);
                Debug.Log("WARN!!!!!");
            }else if (_range > killRange)
            {
                Debug.Log("KILL!!!!!");
//                Kill?.Invoke("Je boot in geraakt door een zeemijn in onbekende wateren. \nNiemand heeft de explosie overleefd.");
            }
            else if(_range <= warnRange)
            {
                _isWarning = false;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, warnRange);
        
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, killRange);
        }
    }
}
