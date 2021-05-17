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

        [SerializeField]
        private Edward.Voiceline _warning;

        private void Start()
        {
            _dialogue = FindObjectOfType<GameEventDialogue>();
        }
        public void RunEvent(GameEvent evt)
        {
            Debug.Log($"Recieved: {evt.eventType}, {evt.str}");

            switch (evt.eventType)
            {
                case GameEventType.GAME_OVER:
                    break;
                case GameEventType.DIALOGUE:
                    _dialogue.Run(_warning);
                    break;
                case GameEventType.LOAD_SCENE:
                    break;
                case GameEventType.WARN:
                    break;
                case GameEventType.WIN_CONDITION:
                    break;
                default:
                    Debug.LogError("Given EventType not valid!");
                    break;
            }
        }

    }
}