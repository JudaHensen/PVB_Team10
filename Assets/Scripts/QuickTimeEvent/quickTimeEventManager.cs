using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quickTimeEventManager : MonoBehaviour
{

    public GameObject iconNorth;
    public GameObject iconEast;
    public GameObject iconSouth;
    public GameObject iconWest;

    private bool _isUIActive = false;
    private QuickTimeInputKey _activeInput;
    private int _numOfMistakes = 0;
    private int _maxNumOfMistakes = 2;

    private float _timeToHit = 1.5f;
    private float _passedTime = 0f;

    private InputManager _input;

    void Start()
    {
        _input = FindObjectOfType<InputManager>();
        _input.SetInputMode(InputMode.QUICK_TIME);
        _input.QuickTimeInput += DisableEventUI;
    }

    private void Update()
    {
        if (_isUIActive)
        {
            _passedTime += Time.deltaTime;
            if(_passedTime >= _timeToHit)
            {
                Debug.Log("LATE!!!!");  
            }
        }
    }
    void DisableEventUI(QuickTimeInputKey input)
    {
        Debug.Log(input);
        switch (input)
        {
            case QuickTimeInputKey.NORTH:
                iconNorth.SetActive(true);
                break;
            case QuickTimeInputKey.EAST:
                iconEast.SetActive(true);
                break;
            case QuickTimeInputKey.SOUTH:
                iconSouth.SetActive(true);
                break;
            case QuickTimeInputKey.WEST:
                iconWest.SetActive(true);
                break;
            default:
                Debug.LogWarning("Incorrect value given!");
                break;
        }
    }



    void EnableEventUI(QuickTimeInputKey input)
    {
        Debug.Log(input);

        iconNorth.SetActive(false);
        iconEast.SetActive(false);
        iconSouth.SetActive(false);
        iconWest.SetActive(false);



        switch (input)
        {
            case QuickTimeInputKey.NORTH:
                iconNorth.SetActive(true);
                break;
            case QuickTimeInputKey.EAST:
                iconEast.SetActive(true);
                break;
            case QuickTimeInputKey.SOUTH:
                iconSouth.SetActive(true);
                break;
            case QuickTimeInputKey.WEST:
                iconWest.SetActive(true);
                break;
            default:
                Debug.LogWarning("Incorrect value given!");
                break;
        }
    }
}
