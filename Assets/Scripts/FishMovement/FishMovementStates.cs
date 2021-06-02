using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FishMovement
{
    public class FishMovementStates : MonoBehaviour
    {
        [SerializeField] private float _swimSpeed = 10f;

        [Header("Target new waypoint when in X distance of current target.")]
        [SerializeField] private float _lookAtDistance = 1f;

        [Header("Makes the fished move a bit smoother, but they take in a lot more space. Might not be usefull for swimming through narrow paths.")]
        [SerializeField] private bool _smoothest = false;

        [SerializeField] private float _minAnimationSpeed = 2;
        [SerializeField] private float _maxAnimationSpeed = 5;

        private GameObject _lookAt;
        private List<GameObject> _wayPoints;

        private Transform _currentWayPoint;
        private Transform _targetWayPoint;
        private int _wayPointIndex = 0;

        private Vector3 _swimPosition;
        private float _lookAtPercent = 0.0f;
        private bool _keepFollowing = false;

        private CustomUtilities.Timer _timer;
        private bool _setup = false;

        private void Start()
        {
            // Get WayPoints
            _wayPoints = new List<GameObject>();
            for(int i = 0; i < transform.parent.Find("WayPoints").childCount; ++i)
            {
                _wayPoints.Add(transform.parent.Find("WayPoints").GetChild(i).gameObject);
                Destroy( _wayPoints[i].GetComponent<MeshRenderer>() ); 
            }

            for (int i = 0; i < transform.childCount; ++i)
            {
                transform.GetChild(i).GetComponent<MeshRenderer>().materials[0].SetFloat("Speed_fish", _minAnimationSpeed + (Random.value * (_maxAnimationSpeed - _minAnimationSpeed)));
            }

            // Get LookAt
            _lookAt = transform.parent.Find("LookAt").gameObject;
            Destroy( _lookAt.transform.GetComponent<MeshRenderer>() );

            _currentWayPoint = _wayPoints[_wayPointIndex].transform;
        }

        private void Update()
        {
            Swim();
        }

        private void Swim()
        {
            // First time call setup.
            if (!_setup)
            {
                float distance;

                _swimPosition = transform.localPosition;

                // Calculate distance
                _wayPointIndex = _wayPoints.IndexOf(_currentWayPoint.gameObject);
                // Setup target and lookAt
                _targetWayPoint = _wayPoints[(_wayPointIndex + 1) % _wayPoints.Count].transform;
                _lookAt.transform.localPosition = _targetWayPoint.localPosition;

                // Setup timer for changing waypoints
                distance = Vector3.Distance(_swimPosition, _targetWayPoint.localPosition);
                _timer = new CustomUtilities.Timer(distance / _swimSpeed);
                
                // Change waypoint
                _timer.OnComplete = () =>
                {
                    _wayPointIndex = (_wayPoints.IndexOf(_currentWayPoint.gameObject) + 1) % _wayPoints.Count;
                    _currentWayPoint = _wayPoints[_wayPointIndex].transform;
                    
                    _lookAtPercent = 0;
                    _setup = false;

                    // Smoothen out movement
                    if(!_smoothest) _keepFollowing = false;
                };

                // Setup complete
                _setup = true;
            }

            // Look & move towards waypoint
            if (Mathf.Abs(Vector3.Distance(transform.localPosition, _targetWayPoint.localPosition)) <= _lookAtDistance || _keepFollowing)
            {
                _keepFollowing = true;

                // Move transform
                float distance = Vector3.Distance(transform.localPosition, _lookAt.transform.localPosition);
                transform.localPosition = Vector3.Slerp(transform.localPosition, _lookAt.transform.localPosition, Time.deltaTime / (distance / _swimSpeed));

                // Move lookAt
                if (_lookAtPercent == 0)
                {
                    _lookAtPercent = _timer.GetPercentage();
                }
                float perc = (_timer.GetPercentage() - _lookAtPercent) / (1 - _lookAtPercent);
                _lookAt.transform.localPosition = Vector3.Lerp(_targetWayPoint.localPosition, _wayPoints[(_wayPointIndex + 2) % _wayPoints.Count].transform.localPosition, perc);
            }
            // Move position
            else transform.localPosition = Vector3.Slerp(_swimPosition, _targetWayPoint.localPosition, _timer.GetPercentage());

            // Rotate all fish individually
            for (int i = 0; i < transform.childCount; ++i)
            {
                transform.GetChild(i).LookAt(_lookAt.transform);
            }

            // Update timer
            _timer.Update();
        }
    }
}
