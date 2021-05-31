using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameEventManagment;
public class GameTimer : MonoBehaviour
{
    GameEventManager _evtManager;
    public Text timeTxt;

    private float _startTime = 540f;
    private float _remainingTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        _remainingTime = _startTime;
        _evtManager = FindObjectOfType<GameEventManager>();
        _evtManager.EndGame += ClearTimer;
        DontDestroyOnLoad(gameObject);    
    }

    void FixedUpdate()
    {
        _remainingTime -= Time.fixedDeltaTime;
        timeTxt.text = $"{Mathf.FloorToInt(_remainingTime / 60)}:{Mathf.FloorToInt(_remainingTime % 60)}";
    }

    private void ClearTimer()
    {
        Destroy(gameObject);
    }
    
}
