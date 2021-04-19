using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeemijnSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _groups = new List<Transform>();
    private int numOfGroups;
    void Awake()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        for (int i = 0; i < GetComponentsInChildren<Transform>().Length; i++)
        {
            if (children[i].name.StartsWith("Group"))
            {
                _groups.Add(children[i]);
            }
        }

        for (int i = 0; i < _groups.Count; i++)
        {
            Transform mine = _groups[i].GetChild(Random.Range(0, _groups[i].childCount));
            mine.gameObject.SetActive(true);
        }
    }
}
