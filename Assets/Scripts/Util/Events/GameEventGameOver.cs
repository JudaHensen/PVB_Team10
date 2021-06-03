using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEventManagment
{
    public class GameEventGameOver : MonoBehaviour
    {
        GameEventManager _evtManager;
        
        private void Start()
        {
            _evtManager = GetComponent<GameEventManager>();
        }
        
        public void Run(int ID)
        {
            _evtManager.RunEvent(new GameEvent(GameEventType.DIALOGUE, ID));
            Debug.Log("YOU LOSE! YOU FUCKING LOSERRR!!!!");
        }
    }
}