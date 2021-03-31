using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarItem : MonoBehaviour
{
    public float timeStamp;

    private GameObject _mine;
    private float _foundDistance;
    private AudioSource _soundPlayer;
    private AudioClip _sound;

    public void InsertData(GameObject mine, float distance, AudioClip sound)
    {
        timeStamp = Time.realtimeSinceStartup;
        _mine = mine;
        _foundDistance = distance;
        _sound = sound;

        // Setup notification sound.
        _soundPlayer = GetComponent<AudioSource>();
        _soundPlayer.clip = _sound;
        _soundPlayer.Play();
    }

    public string GetUniqueID()
    {
        return _mine.GetComponent<MineLocation>().uniqueID;
    }

}
