using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Edward {
    [CreateAssetMenu(fileName = "EdwardVoiceLine", menuName = "Edward/Voiceline", order =1 )]
    public class Voiceline : ScriptableObject
    {
        public string previewName;
        public string message;
        public AudioClip voiceMessage;

        public float displayTime;
        [Header("Overwrites if the typeSpeed takes longer than the display time.")]
        public float typeSpeed;

        public string parameterName;
        public string parameterValue;
    }
}