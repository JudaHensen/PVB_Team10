using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEventManagment
{
    public class GameEventWin : MonoBehaviour
    {
        private GameEventManager _evtManager;
        private void Start()
        {
            _evtManager = FindObjectOfType<GameEventManager>();
        }
        public void Run()
        {
            Debug.Log("YOU WIN! Good job.");
        }
    }
}