using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    private List<GameObject> _destroyOnTrigger = new List<GameObject>();

    // Load a new scene, but don't destroy gameobjects in list yet
    public void SwitchScene(string sceneName)
    {
        DontDestroyOnLoad(gameObject);

        for(int i = 0; i < _destroyOnTrigger.Count; ++i)
        {
            DontDestroyOnLoad(_destroyOnTrigger[i]);
        }

        SceneManager.LoadScene(sceneName);
    }

    // Activate function to destroy all gameobjects in list, including this gameobject
    public void Trigger()
    {
        for(int i = 0; i < _destroyOnTrigger.Count; ++i)
        {
            _destroyOnTrigger[i].SetActive(false);
            Destroy(_destroyOnTrigger[i]);
        }

        Destroy(gameObject);
    }

    // Add gameobject to list of objects to destroy when told too
    public void Add(GameObject obj)
    {
        if(!_destroyOnTrigger.Contains(obj))
        {
            _destroyOnTrigger.Add(obj);
        }
    }

    // Add gameobject to list of objects to destroy when told too
    // Finds object based on name
    public void Add(string name) {
        GameObject obj = GameObject.Find(name);
        if (obj) Add(obj);
    }

    // Removes gameobject from list of objects
    public void Remove(GameObject obj)
    {
        if (_destroyOnTrigger.Contains(obj))
        {
            _destroyOnTrigger.Remove(obj);
        }
    }

    // Removes gameobject from list of objects
    // Finds object based on name
    public void Remove(string name)
    {
        GameObject obj = GameObject.Find(name);
        if(obj) Remove(obj);
    }

}
