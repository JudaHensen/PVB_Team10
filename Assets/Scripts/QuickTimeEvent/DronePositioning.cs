using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controls;

public class DronePositioning : MonoBehaviour
{
    private InputManager _input;
    private Transform _mine; // tranform van de mine waarmee je interact.

    // activeer deze functie zodra het QTE aangeroepen wordt
    // zet de Y pos van de speler op dezelfde waarde als die van de mijn
    // zet de positie van de speler op x afstand van de mijn af
    // zet de rotatie van de speler naar de mijn toe.
    // hierna is het QTE duidelijk te zien

    //waar moet dit script op staan?
    //in welke map moet dit script staan?
    //hoe check ik of de QTE is aangeroepen?
    void Start()
    {
        _input = FindObjectOfType<InputManager>();
        _input.InputMode += Positioning;
    }

    private void Positioning(ControllerInputMode mode)
    {
        if (mode == ControllerInputMode.QUICK_TIME)
        {
            //transform vector3(y = Get.gameobject.zeemijn.y);
            GetComponent<Vector3.GameObject._mine.y>
            //transform.position == gameobject.zeemijn.position + (pos.X + 10);
            transform.LookAt(_mine);
        }
    }
}
// get mine of interaction
// that mine position of center collider (transform
// larp de drone naar die positie, en neem y as over.