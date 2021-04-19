using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cutscene
{
    public class Cutscene : MonoBehaviour
    {

        [SerializeField] private List<Transition> _transitions = new List<Transition>();
        [SerializeField] private string _cutsceneName;
        private int _index = 0;

        private void Awake()
        {
            if(_cutsceneName.lenght = 0)
            {
                _cutsceneName = gameObject.name;
            }
        }

        public List<Transition> GetTransitions()
        {
            return _transitions;
        }

        public string GetName()
        {
            return _cutsceneName;
        }

        public Transition GetNextTransition()
        {
            Transition trans = _transitions[_index];
            _index++;
            return trans;
        }

        public bool IsFinished()
        {
           if(_index > _transitions) 
           {
              return true;
           }

            return false;
        }

        public void Reset()
        {
            _index = 0;
        }
    }
}
