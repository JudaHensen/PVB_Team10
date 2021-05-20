using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CustomFMOD
{
    public class FMOD_AudioHandler : MonoBehaviour
    {
        private FMOD_AudioTrigger[] _triggers;

        // Start is called before the first frame update
        void Start()
        {
            // Search all Audio Triggers
            Search();
            DontDestroyOnLoad(gameObject);
        }

        public FMOD_AudioTrigger GetTrigger(string name)
        {
            for(int i = 0; i < _triggers.Length; ++i)
            {
                if(_triggers[i].GetName().ToLower() == name.ToLower())
                {
                    return _triggers[i];
                }
            }
            throw new Exception($"Could not find a trigger with the name: {name}");
        }

        public void Trigger(string name) {
            FMOD_AudioTrigger trigger = GetTrigger(name);

            trigger.Trigger();
        }

        public void Trigger(string name, object obj)
        {
            FMOD_AudioTrigger trigger = GetTrigger(name);

            if( obj is bool)
            {
                trigger.Trigger( (bool) obj );
            }
            else if(obj is float)
            {
                trigger.Trigger( (float) obj );
            }
            else
            {
                throw new Exception($"Trigger object type: {obj.GetType()} is not allowed!");
            }
        }

        // Search all Audio Triggers
        public void Search()
        {
            _triggers = FindObjectsOfType<FMOD_AudioTrigger>();
            DontDestroyOnLoad(gameObject);
        }


    }
}
