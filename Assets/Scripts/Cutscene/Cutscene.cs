using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Cutscene
{
    public class Cutscene : MonoBehaviour
    {
        [SerializeField] private string _cutsceneName;
        [SerializeField] private List<GameObject> _transitions = new List<GameObject>();
        [SerializeField] private bool _createNewCamera = true;
        
        private int _index = 0;


        private void Awake()
        {
            if(_cutsceneName.Length == 0)
            {
                _cutsceneName = gameObject.name;
            }
        }

        public List<GameObject> GetTransitions()
        {
            return _transitions;
        }

        public string GetName()
        {
            return _cutsceneName;
        }

        public Transition GetNextTransition()
        {
            if (IsFinished()) throw new Exception("Requested transition is out of index!");
            Transition trans = _transitions[_index].GetComponent<Transition>();
            _index++;
            return trans;
        }

        public bool IsFinished()
        {
           if(_index >= _transitions.Count) 
           {
              return true;
           }

            return false;
        }

        public void Reset()
        {
            _index = 0;
            for(int i = 0; i < _transitions.Count; ++i)
            {
                _transitions[i].GetComponent<Transition>().Reset();
            }
        }

        public bool GetNewCamera()
        {
            return _createNewCamera;
        }

    }
}
