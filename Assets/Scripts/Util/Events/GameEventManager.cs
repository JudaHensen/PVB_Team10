using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World;

namespace GameEventManagment
{
    public class GameEventManager : MonoBehaviour
    {
        private WorldBorder _border;
        private GameEventDialogue _dialogue;
        private GameEventGameOver _gameOver;
        private GameEventWin _win;

        private void Start()
        {
            _dialogue = FindObjectOfType<GameEventDialogue>();
        }
        public void RunEvent(GameEvent evt)
        {
            Debug.Log($"Recieved: {evt.eventType}, {evt.ID}");

            switch (evt.eventType)
            {
                case GameEventType.GAME_OVER:
                    _gameOver.Run(evt.ID);
                    break;
                case GameEventType.DIALOGUE:
                    _dialogue.Run(evt.ID);
                    break;
                case GameEventType.WIN_CONDITION:
                    _win.Run();
                    break;
                default:
                    Debug.LogError("Given EventType not valid!");
                    break;
            }
        }

    }
}