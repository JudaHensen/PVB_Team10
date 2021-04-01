using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Sonar : MonoBehaviour
{
    [Header("Sweeper settings.")]
    [SerializeField]
    private float _height;
    [SerializeField]
    private float _range;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private bool _visible;

    public event Action<float> SetMaximumRange;
    public event Action<float, float, Vector2> UpdateSonarUI;
    public event Action<string, List<SonarItem>> DetectMine;
    public event Action<string, List<SonarItem>> RemoveMine;

    // Found mines
    [SerializeField]
    private AudioClip _sound;
    [SerializeField]
    [Header("Delay in seconds before the same mine can be found again.")]
    private float _foundDelay;
    [SerializeField]
    private float _destroyRange;
    [SerializeField]
    private GameObject _sonarItemPrefab;
    private Transform _sonarItemParent;
    private List<SonarItem> _foundMines;

    private void Start()
    {
        // Create Sonar mesh
        // _speed / 24 frames p/s * 2.5 to make sure the sweeper won't skip any mines.
        SonarMesh sonarMesh = new SonarMesh(_speed / 24 * 2.5f, _height, _range, this.transform);
        GetComponent<MeshRenderer>().enabled = _visible;

        _foundMines = new List<SonarItem>();
        _sonarItemParent = transform.Find("SonarItems");

        SetMaximumRange(_range);
    }

    #region Updates
    private void Update()
    {
        UpdateSweeper();
        UpdateSonar();
        try {
            UpdateSonarUI(
                _speed * Time.deltaTime, 
                transform.parent.eulerAngles.y, 
                new Vector2(transform.parent.position.x, transform.parent.position.z));
        } catch(Exception e) {
            // Triggers when no class assigned a function to the event.
        }
    }

    // Update physical sweeper.
    private void UpdateSweeper()
    {
        transform.Rotate(0, _speed * Time.deltaTime, 0, Space.Self);
    }

    // Update sonar user interface.
    private void UpdateSonar()
    {
        // Remove mines out of range.
        for(int i = _foundMines.Count-1; i >= 0; --i)
        {
            MineLocation mine = _foundMines[i].GetMineLocation();//.transform;
            // might be fine as long as the ship is the sonar's parent
            float distance = Vector2.Distance(
                new Vector2( transform.parent.position.x, transform.parent.position.z), 
                new Vector2(mine.location.x, mine.location.y) );

            if (distance < 0) distance = -distance;
            if (distance >= _destroyRange)
            {
                string uniqueID = _foundMines[i].GetUniqueID();
                _foundMines.RemoveAt(i);
                
                // Send removed mine.
                RemoveMine(uniqueID, _foundMines);
            }
        }

    }
    #endregion

    #region Collissions
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag.ToLower() == "mine")
        {
            // Calculate distance
            float distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(collider.transform.position.x, collider.transform.position.z));
            if (distance < 0) distance = -distance;
            distance /= _range;

            // Check if mine is newly found
            if (!ContainsUniqueID(collider.GetComponent<MineLocation>().uniqueID))
            {
                // Add mine to list
                GameObject sonarItem = Instantiate(_sonarItemPrefab, Vector3.zero, Quaternion.identity);
                sonarItem.transform.parent = _sonarItemParent;

                sonarItem.GetComponent<SonarItem>().InsertData(collider.gameObject, distance, _sound);
                _foundMines.Add(sonarItem.GetComponent<SonarItem>());
                
                // Send added mine
                DetectMine(sonarItem.GetComponent<SonarItem>().GetUniqueID(), _foundMines);
            }
            // Check if mine is found and meets requirements
            else if (Time.realtimeSinceStartup >= _foundMines[GetMineIndex(collider.GetComponent<MineLocation>().uniqueID)].timeStamp + _foundDelay)
            {
                // Update mine
                _foundMines[GetMineIndex(collider.GetComponent<MineLocation>().uniqueID)].UpdateData(distance);
            }
            else Debug.Log("Mine with uniqueID has already been spotted.");
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag.ToLower() == "mine")
        {
            // Maybe make a mine available to find again?
        }
    }
    #endregion

    #region SearchFunctions
    // Checks if a mine with uniqueID already has been found.
    private bool ContainsUniqueID(string uniqueID)
    {
        for(int i = 0; i < _foundMines.Count; ++i)
        {
            if (_foundMines[i].GetUniqueID() == uniqueID) return true;
        }
        return false;
    }

    private int GetMineIndex(string uniqueID)
    {
        for (int i = 0; i < _foundMines.Count; ++i)
        {
            if (_foundMines[i].GetUniqueID() == uniqueID) return i;
        }
        throw new Exception("Could not find index!");
    }
    #endregion

}
