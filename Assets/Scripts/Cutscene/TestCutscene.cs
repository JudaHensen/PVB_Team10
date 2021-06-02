using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controls;

public class TestCutscene : MonoBehaviour
{
    [SerializeField] private string _cutscene;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Cutscene to play: {_cutscene}");
        FindObjectOfType<InputManager>().Interact += () =>
        {
            Debug.Log($"PlayingCutscene: {_cutscene}");

            // Obtain cutscene handler
            Cutscene.CutsceneHandler _cutsceneHandler = GameObject.Find("CutsceneManager").GetComponent<Cutscene.CutsceneHandler>();

            // Play cutscene
            _cutsceneHandler.StartCutscene(_cutscene);
        };
    }
}
