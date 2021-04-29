using Controls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionDetect : MonoBehaviour
{
    private InputManager _input;
    private bool isinteraction;
    [SerializeField]
    private GameObject interactText;

    void Start()
    {
        _input = FindObjectOfType<InputManager>();
        _input.Interact += Interaction;
        interactText.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("ship"))
        {
            isinteraction = true;
            interactText.SetActive(true);
            print("aah");

        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("ship"))
        {
            isinteraction = false;
            interactText.SetActive(false);
        }
       
    }

    private void Interaction()
    {
        SceneManager.LoadScene("OnderWater");
    }
}
