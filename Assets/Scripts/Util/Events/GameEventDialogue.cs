using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserInterface;

namespace GameEventManagment
{
    public class GameEventDialogue : MonoBehaviour
    {
        private Subtitles.EdwardManager _edManager;

        public List<Edward.Voiceline> voiceLines = new List<Edward.Voiceline>();

        private void Start()
        {
            _edManager = FindObjectOfType<Subtitles.EdwardManager>();
        }

        public void Run(int ID)
        {
            for (int i = 0; i < voiceLines.Count; i++)
            {
                if(ID == voiceLines[i].id)
                {
                    _edManager.SetVoiceline(voiceLines[i]);
                }
            }
        }
    }
}