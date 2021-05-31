using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEventManagment;
public class ExplodeDetection : MonoBehaviour
{
    GameEventManager _evtManager;

    private void Start()
    {
        _evtManager = FindObjectOfType<GameEventManager>();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Ship"))
        {
            // Run Game Over event voor een zeemijn raken met het schip.
            _evtManager.RunEvent(new GameEvent(GameEventType.GAME_OVER, 3));
            Debug.Log("Ship exploded!");
        }
    }
}
