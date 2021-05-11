using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace World
{
    public class WorldBorder : MonoBehaviour
    {
        // Triggers om de zones te defineren
        public Transform target;
        public float warnRange;
        public float killRange;

        // Deligates om de functies uit te voeren.
        public Action<bool> Warn;
        public Action Kill;

        private float _range;

        private void FixedUpdate()
        {
            _range = Vector3.Distance(transform.position, target.position);

            if (_range >= warnRange && _range < killRange)
            {
                Warn?.Invoke(true);
                Debug.Log("WARN!!!!!");
            }else if (_range > killRange)
            {
                Warn?.Invoke(false);
                Debug.Log("KILL!!!!!");
                Kill?.Invoke();
            }
            else
            {
                Warn?.Invoke(false);
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
