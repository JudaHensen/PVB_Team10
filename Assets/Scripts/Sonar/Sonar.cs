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
    private bool _visual;

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
        // Create Sonar mesh.
        // speed / 24 frames p/s * 2.5 to make sure the sweeper won't skip any mines.
        SonarMesh sonarMesh = new SonarMesh(_speed / 24 * 2.5f, _height, _range, this.transform);
        GetComponent<MeshRenderer>().enabled = _visual;

        _foundMines = new List<SonarItem>();
        _sonarItemParent = transform.parent.Find("SonarItems");
    }

    private void Update()
    {
        UpdateSweeper();
        UpdateSonar();
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
            Transform mine = _foundMines[i].transform;
            float distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(mine.transform.position.x, mine.transform.position.z));
            if (distance < 0) distance = -distance;
            if (distance >= _destroyRange)
            {
                Destroy(mine.gameObject);
                _foundMines.RemoveAt(i);
            }
        }

    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag.ToLower() == "mine")
        {
            // Calculate distance.
            float distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(collider.transform.position.x, collider.transform.position.z));
            if (distance < 0) distance = -distance;
            distance /= _range;

            // Check if mine is newly found.
            if (!ContainsUniqueID(collider.GetComponent<MineLocation>().uniqueID))
            {
                
                GameObject sonarItem = Instantiate(_sonarItemPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                sonarItem.transform.parent = _sonarItemParent;

                sonarItem.GetComponent<SonarItem>().InsertData(collider.gameObject, distance, _sound);
                _foundMines.Add(sonarItem.GetComponent<SonarItem>());
            }
            // Check if mine is found and meets requirements.
            else if (Time.realtimeSinceStartup >= _foundMines[GetMineIndex(collider.GetComponent<MineLocation>().uniqueID)].timeStamp + _foundDelay)
            {
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

}
