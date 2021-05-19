using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Edward {
    [CreateAssetMenu(fileName = "EdwardVoiceLine", menuName = "Edward/Voiceline", order =1 )]
    public class Voiceline : ScriptableObject
    {
        public string previewName;
        
        [Multiline] public string message;

        public float displayTime;
        [Header("Overwrites if the typeSpeed takes longer than the display time.")]
        public float typeSpeed;

        public int id;
    }
}