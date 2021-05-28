using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System.Threading.Tasks;

namespace CustomFMOD
{
    public class FMOD_AudioTrigger : MonoBehaviour
    {
        [SerializeField] protected string Name;
        [SerializeField] protected bool SingleInstance = true;
        [SerializeField] protected string ParameterName;
        [SerializeField] protected float EnabledValue = 1;
        [SerializeField] protected float DisabledValue = 0;

        private FMODUnity.StudioEventEmitter _emitter;

        void Awake()
        {
            _emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        }

#region Triggers

        public void Trigger()
        {
            if(SingleInstance)
            {
                if(!_emitter.IsPlaying())
                {
                    _emitter.Play();
                }
            }
            else {
                _emitter.Play();
            }
        }

        public void Trigger(bool active)
        {
            // Play sound if not playing
            Trigger();

            // Change parameter
            if(active) _emitter.SetParameter(ParameterName, EnabledValue, false);
            else _emitter.SetParameter(ParameterName, DisabledValue, false);
        }

        public void Trigger(float value)
        {
            // Play sound if not playing
            Trigger();

            // Change parameter
            _emitter.SetParameter(ParameterName, value, false);
        }

        public void Stop()
        {
            if(_emitter.IsPlaying()) _emitter.Stop();
        }

        public void ChangeParameter(float value)
        {
            _emitter.SetParameter(ParameterName, value, false);
        }

#endregion

#region Getters

        public string GetName()
        {
            return Name;
        }

        public bool MatchName(string name)
        {
            if (name == Name) return true;
            return false;
        }
#endregion
    }
}
