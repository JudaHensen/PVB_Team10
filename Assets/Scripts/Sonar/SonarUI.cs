using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonarUI : MonoBehaviour
{
    [SerializeField]
    private string _shipSonarName;
    [SerializeField]
    private GameObject _mineUIPrefab;
    [SerializeField]
    private float _rotationOffset;

    private Transform _sweeper;
    private Transform _mineDisplay;

    private float _shipRotation;
    private Vector2 _shipLocation;

    private float _displaySize;
    private float _maxRange;
    private List<MineLocation> _mineLocations = new List<MineLocation>();

    private void Awake()
    {
        // Setup variables & actions
        Sonar sonar = GameObject.Find(_shipSonarName).GetComponent<Sonar>();
        sonar.UpdateSonarUI += UpdateSonarUI;
        sonar.DetectMine += DetectMine;
        sonar.RemoveMine += RemoveMine;
        sonar.SetMaximumRange += SetMaximumRange;

        _sweeper = transform.Find("Sweeper");
        _mineDisplay = transform.Find("MineDisplay");

        _displaySize = GetComponent<RectTransform>().sizeDelta.x/2;
        _mineDisplay.GetComponent<RectTransform>().localEulerAngles = new Vector3(0, 0, _rotationOffset);
    }

    #region Usefull Functions
    public void SetMaximumRange(float range) {
        _maxRange = range;
    }

    // Get position for sonar
    private Vector2 GetPosition(Vector2 position)
    {
        float x, y;
        Vector2 relPos = GetRelativePosition(position);
        x = relPos.x * _displaySize;
        y = relPos.y * _displaySize;
        return new Vector2(-x, -y);
    }

    // Get relative position within -1 -> 1 from the ship's location
    private Vector2 GetRelativePosition(Vector2 position)
    {
        float x, y;
        x = (_shipLocation.x - position.x) / _maxRange;
        y = (_shipLocation.y - position.y) / _maxRange;
        return new Vector2(x, y);
    }
    #endregion

    #region Updates
    // Update the rotation of the sweeper.
    private void UpdateSonarUI(float sweeperRotation, float shipRotation, Vector2 shipLocation)
    {
        // Update sweeper rotation
        _sweeper.Rotate(0, 0, -sweeperRotation, Space.Self);
        _shipRotation = shipRotation;
        _shipLocation = shipLocation;

        UpdateMineDisplay();
    }

    // Update the mine display's mine location.
    private void UpdateMineDisplay()
    {
        // Update visual mine locations
        foreach(MineLocation mineLocation in _mineLocations)
        {
            GameObject mineUI = _mineDisplay.Find($"Mine:{mineLocation.uniqueID}").gameObject;
            mineUI.GetComponent<RectTransform>().anchoredPosition = GetPosition(mineLocation.location);
        }

        // Update visual rotation
        _mineDisplay.GetComponent<RectTransform>().localEulerAngles = new Vector3(0, 0, _shipRotation + _rotationOffset);
    }
    #endregion

    #region MineDetection
    private void DetectMine(string uniqueID, List<SonarItem> sonarItems)
    {
        // Replace mine array
        _mineLocations.Clear();
        foreach(SonarItem sonarItem in sonarItems)
        {
            _mineLocations.Add( sonarItem.GetMineLocation() );

            if (sonarItem.GetUniqueID() == uniqueID)
            {
                // Add new mine sprite on location
                GameObject mineSprite = Instantiate(
                    _mineUIPrefab,
                    Vector3.zero,
                    Quaternion.identity);

                mineSprite.name = $"Mine:{uniqueID}";
                mineSprite.transform.parent = _mineDisplay;

                mineSprite.GetComponent<RectTransform>().anchoredPosition = GetPosition(sonarItem.GetMineLocation().location);
                mineSprite.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }
        }
    }

    private void RemoveMine(string uniqueID, List<SonarItem> sonarItems)
    {
        Debug.Log($"Removing mine: {uniqueID}");

        // Replace mine array
        _mineLocations.Clear();
        foreach (SonarItem sonarItem in sonarItems)
        {
            _mineLocations.Add(sonarItem.GetMineLocation());
        }

        // Remove mine sprite
        Destroy(_mineDisplay.Find($"Mine:{uniqueID}").gameObject);
    }
    #endregion
}
