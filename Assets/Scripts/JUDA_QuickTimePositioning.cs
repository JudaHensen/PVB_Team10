using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUDA_QuickTimePositioning : MonoBehaviour
{
    [SerializeField] private GameObject _drone;
    [SerializeField] private float _lerpTime = 2f;

    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private Vector3 _endPosition;
    private Quaternion _endRotation;

    private CustomUtilities.Timer _timer;
    private bool _isActive = false;

    private void Start()
    {
        PositionDrone();
    }

    public void PositionDrone()
    {
        // Disable drone movement
        _drone.GetComponent<DroneMovement>().enabled = false;

        _startPosition = _drone.transform.position;
        _startRotation = _drone.transform.rotation;

        _endPosition = transform.position;
        _endRotation = transform.rotation;

        _timer = new CustomUtilities.Timer(_lerpTime);

        _isActive = true;
    }
 
    void Update()
    {
        try
        {
            if (_isActive)
            {
                if (_timer.Completed())
                {
                    _drone.transform.position = _endPosition;
                    _drone.transform.rotation = _endRotation;

                    _isActive = false;
                }
                else
                {
                    _timer.Update();

                    float interpolation = _timer.GetTime() / _lerpTime;

                    _drone.transform.position = Vector3.Lerp(_startPosition, _endPosition, interpolation);
                    _drone.transform.rotation = Quaternion.Lerp(_startRotation, _endRotation, interpolation);
                }
            }
        }
        catch
        {
            // Errors while scene switching
        }
    }
}
