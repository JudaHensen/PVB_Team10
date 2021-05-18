using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cutscene;

public class SceneSwitch : MonoBehaviour
{
    [Header("GameObjects to be removed after the cutscene has stopped.")]
    [SerializeField] private List<GameObject> _destroyOnTrigger = new List<GameObject>();

    [Header("GameObjects to be removed instantly when called to avoid update errors.")]
    [SerializeField] private List<GameObject> _destroyInstantly = new List<GameObject>();

    [SerializeField] private string _sceneToLoad;
    [SerializeField] private string _cutscene;
    [SerializeField] private Vector3 _teleportTo = new Vector3();

    // Load a new scene, but don't destroy gameobjects in list yet
    public void SwitchScene()
    {
        DontDestroyOnLoad(gameObject);

        // Mark objects as dont destroy on load
        for(int i = 0; i < _destroyOnTrigger.Count; ++i)
        {
            DontDestroyOnLoad(_destroyOnTrigger[i]);

            // Teleport gameobjects upwards, so the camera cannot see the currently loading scene.
            Vector3 pos = _destroyOnTrigger[i].transform.position;
            pos += _teleportTo;
            _destroyOnTrigger[i].transform.position = pos;
        }

        // Destroy objects which can cause errors
        for(int i = 0; i < _destroyInstantly.Count; ++i)
        {
            Destroy(_destroyInstantly[i]);
        }
        
        // Disable canvas
        GameObject.Find("Canvas").SetActive(false);

        // Obtain cutscene handler
        Cutscene.CutsceneHandler cutsceneHandler = GameObject.Find("CutsceneManager").GetComponent<CutsceneHandler>();

        // Lambda expression to avoid writing an unnecessary function 
        cutsceneHandler.OnFinished += () =>
        {
            Trigger();
        };

        // Play cutscene
        cutsceneHandler.StartCutscene(_cutscene);

        // Load scene in background;
        SceneManager.LoadSceneAsync(_sceneToLoad);
    }

    // Activate function to destroy all gameobjects in list, including this gameobject
    public void Trigger()
    {
        for(int i = 0; i < _destroyOnTrigger.Count; ++i)
        {
            _destroyOnTrigger[i].SetActive(false);
            Destroy(_destroyOnTrigger[i]);
        }

        // Enable main camera
        GameObject[] cameras = GameObject.FindGameObjectsWithTag("MainCamera");
        for(int i = 0; i < cameras.Length; ++i)
        {
            cameras[i].GetComponent<Camera>().enabled = true;
        }

        Destroy(gameObject);
    }

#region Add & Remove

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

#endregion

}
